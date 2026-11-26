using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using _6_6_BankAtmMdiSystem.DAL;
using _6_6_BankAtmMdiSystem.DTO;

namespace _6_6_BankAtmMdiSystem.BUS
{
    public class AtmReconciliationBUS
    {
        private readonly AtmTransactionDAL _transactionDal = new AtmTransactionDAL();

        public async Task<List<AtmTransactionDTO>> RunReconciliationAsync(
            DateTime ngayDoiSoat,
            IProgress<ReconciliationProgressDTO> progress,
            CancellationToken cancellationToken)
        {
            return await Task.Run(async () =>
            {
                var steps = new List<(int Percent, string Message, int DelayMs)>
                {
                    (15, $"Kết nối Core Banking & tải 320.000 sao kê ngày {ngayDoiSoat:dd/MM/yyyy}...", 1000),
                    (38, "Giải mã nhật ký điện tử (EJ Log) từ các trạm ATM toàn mạng lưới...", 1000),
                    (62, "Đối chiếu giao dịch rút tiền mặt & kiểm tra mã chuẩn chi (Auth Code)...", 1100),
                    (85, "Đối chiếu giao dịch chuyển khoản liên ngân hàng NAPAS 24/7...", 1000),
                    (100, "Truy xuất danh sách giao dịch sai lệch từ cơ sở dữ liệu...", 900)
                };

                foreach (var step in steps)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    progress?.Report(new ReconciliationProgressDTO
                    {
                        Percent = step.Percent,
                        StepMessage = step.Message
                    });

                    // Tổng thời gian 5 bước = 5.0 giây (đúng yêu cầu 4 - 6 giây)
                    await Task.Delay(step.DelayMs, cancellationToken);
                }

                cancellationToken.ThrowIfCancellationRequested();
                return _transactionDal.GetMismatchedTransactionsByDate(ngayDoiSoat);
            }, cancellationToken);
        }
    }
}