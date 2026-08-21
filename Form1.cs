using System.Diagnostics;

namespace TaskProcessor
{
    public partial class Form1 : Form
    {
        // 用于取消任务的令牌源
        //声明一个"可空的任务取消器"
        private CancellationTokenSource? cts;

        // 记录总耗时
        private Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // ========== 开始任务按钮 ==========
        private async void btnStart_Click(object sender, EventArgs e)
        {
        
            // 获取任务数量
            int totalTasks = (int)numCount.Value;

            // 初始化界面
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            lstLog.Items.Clear();
            progressBar.Value = 0;
            lblProgress.Text = "0%";
            lblCurrent.Text = "准备开始...";

            // 创建取消令牌源
            cts = new CancellationTokenSource();

            // 记录开始时间
            stopwatch.Restart();

            try
            {
                // 调用异步方法执行任务
                await RunTasksAsync(totalTasks, cts.Token);

                // 任务正常完成
                stopwatch.Stop();
                lblCurrent.Text = "全部完成！";
                AddLog($"✅ 全部完成！总耗时 {stopwatch.Elapsed.TotalSeconds:F2} 秒");
            }
            catch (OperationCanceledException)
            {
                // 任务被取消
                stopwatch.Stop();
                lblCurrent.Text = "已取消";
                AddLog($"⛔ 任务已取消，已耗时 {stopwatch.Elapsed.TotalSeconds:F2} 秒");
            }
            catch (Exception ex)
            {
                // 其他异常
                AddLog($"❌ 错误：{ex.Message}");
            }
            finally
            {
                // 恢复界面状态
                btnStart.Enabled = true;
                btnCancel.Enabled = false;
                cts?.Dispose();
                cts = null;
            }
        }

        // ========== 取消按钮 ==========
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            btnCancel.Enabled = false;
            lblCurrent.Text = "正在取消...";
        }

        // ========== 核心：异步执行任务 ==========
        //这个函数实际上做的是
        //for (每个任务) {
        //检查是否取消
        //更新界面文字
        //假装工作一会儿（用Task.Delay模拟）
        //更新进度条
        //记录日志
        //}
        private async Task RunTasksAsync(int totalTasks, CancellationToken token)
        {
            var random = new Random();

            for (int i = 1; i <= totalTasks; i++)
            {
                // 检查是否请求取消
                token.ThrowIfCancellationRequested();

                // 更新当前任务信息（必须在 UI 线程）
                int currentTask = i;
                await InvokeAsync(() =>
                {
                    lblCurrent.Text = $"正在处理第 {currentTask}/{totalTasks} 个任务...";
                });

                // 模拟耗时任务（随机 50-200 毫秒）
                // 假装工作了XXX毫秒
                int delayMs = random.Next(50, 200);
                await Task.Delay(delayMs, token);

                // 更新进度条（必须在 UI 线程）
                int percent = (int)((double)currentTask / totalTasks * 100);
                await InvokeAsync(() =>
                {
                    progressBar.Value = percent;
                    lblProgress.Text = $"{percent}%";
                });

                // 添加日志（必须在 UI 线程）
                await InvokeAsync(() =>
                {
                    AddLog($"任务 {currentTask} 完成，耗时 {delayMs}ms");
                });
            }
        }

        // ========== 辅助方法：安全更新 UI ==========
        // 如果当前在 UI 线程直接执行，否则 Invoke
        //这段代码的作用：安全地在 UI 线程执行操作，并让 UI 有机会刷新
        private async Task InvokeAsync(Action action)
        {
            if (InvokeRequired)
            {
                await Task.Run(() => Invoke(action));
            }
            else
            {
                action();
            }
            // 让 UI 有时间刷新
            await Task.Yield();
            // 作用：强制让出 UI 线程
            // UI 线程可以处理消息队列中的其他消息
            // 包括 WM_PAINT（重绘界面）
        }

        // ========== 辅助方法：添加日志 ==========
        private void AddLog(string message)
        {
            lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            // 自动滚动到底部
            lstLog.TopIndex = lstLog.Items.Count - 1;
        }
    }
}