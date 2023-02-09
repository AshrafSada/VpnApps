using VpnApps.BasicVpn;
using static System.Console;

internal static class Program
{
    private static void Main(string[] args)
    {
        WriteLine("Basic VPN App");

        WriteLine("Connect VPN [y]/[N]?");

        char result = Convert.ToChar(ReadLine());

        if (result == 'y' || result == 'Y')
        {
            RasManager.ConnectVpn();
        }
        else
        {
            WriteLine("OK got it!");
        }
    }
}
