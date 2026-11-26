using _6_7_PowerGridScadaSystem.DAL;
using _6_7_PowerGridScadaSystem.DTO;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace _6_7_PowerGridScadaSystem.BUS
{
    public class ScadaMonitorBUS
    {
        private readonly OverloadLogDAL _overloadLogDal = new OverloadLogDAL();

        // Sự kiện được kích hoạt trực tiếp từ Background Thread (ThreadPool)
        public event Action<TelemetryDataDTO> TelemetryReceived;

        public Task StartMonitoringLoopAsync(SubstationDTO substation, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                Random random = new Random();
                int cycleCount = 0;

                while (!cancellationToken.IsCancellationRequested)
                {
                    cycleCount++;

                    // Sinh ngẫu nhiên Điện áp (108.0 kV - 115.0 kV) và Mức tải (50% - 98%)
                    double voltage = Math.Round(108.0 + random.NextDouble() * 7.0, 1);
                    int loadPercent = random.Next(50, 99);
                    DateTime now = DateTime.Now;

                    var telemetry = new TelemetryDataDTO
                    {
                        MaTram = substation.MaTram,
                        TenTram = substation.TenTram,
                        DienApKV = voltage,
                        MucMangTaiPercent = loadPercent,
                        ThoiGianNhan = now,
                        ChuKyQuet = cycleCount
                    };

                    // Nếu vượt ngưỡng an toàn (> 85%), ghi nhận sự cố xuống SQL Server
                    if (telemetry.IsOverload)
                    {
                        try
                        {
                            _overloadLogDal.Insert(new OverloadLogDTO
                            {
                                MaTram = substation.MaTram,
                                TenTram = substation.TenTram,
                                ThoiGianGhiNhan = now,
                                DienApKV = voltage,
                                MucMangTaiPercent = loadPercent,
                                MucDoCanhBao = loadPercent >= 95 ? "QUÁ TẢI NGHIÊM TRỌNG" : "CẢNH BÁO QUÁ TẢI (> 85%)",
                                ChuKyQuet = cycleCount
                            });
                        }
                        catch
                        {
                            // Bỏ qua lỗi ghi DB nếu chưa khởi chạy SQL Server để không gián đoạn luồng SCADA
                        }
                    }

                    // Gửi gói tin sang GUI (đang chạy trên Background Thread nên GUI bắt buộc phải dùng Invoke)
                    TelemetryReceived?.Invoke(telemetry);

                    // Chu kỳ quét định kỳ 2 giây/lần
                    await Task.Delay(2000, cancellationToken);
                }
            }, cancellationToken);
        }
    }
}