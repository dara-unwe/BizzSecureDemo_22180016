/*namespace BizzSecureDemo_22180016.ViewModels;

public class Replay_Demo
{

}*/

namespace BizzSecureDemo_22180016.ViewModels
{
    public class ReplayDemoVm
    {
        public decimal Balance { get; set; }
        public string? Message { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; } = 100;
        public string Token { get; set; } = "SECRET123";
        public string Nonce { get; set; } = string.Empty;
    }
}
