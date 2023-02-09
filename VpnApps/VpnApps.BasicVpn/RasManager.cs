using System.Text;

namespace VpnApps.BasicVpn;

internal class RasManager
{
    private const string SERVER_ADDRESS = "us2.vpnbook.com";
    private const string USER_NAME = "vpnbook";
    private const string USER_PWD = "xkud5hn";

    public static void ConnectVpn()
    {
        if (CreateRasphoneFile())
        {
            // TODO: connect to server
        }
    }

    private static bool CreateRasphoneFile()
    {
        string userProfilePath = Environment.GetFolderPath(
           Environment.SpecialFolder.UserProfile);
        string rasFolder = @"AppData\Roaming\Microsoft\Network\Connections\Pbk";
        string pbkFile = Path.Combine(userProfilePath, rasFolder, "rasphone.pbk ");

        var sb = new StringBuilder();
        sb.AppendLine("[MyVPNServer]");
        sb.AppendLine("MEDIA=rastapi");
        sb.AppendLine("Port=VPN2-0");
        sb.AppendLine("Device=WAN Miniport (IKEv2)");
        sb.AppendLine("DEVICE=vpn");
        sb.AppendLine($"PhoneNumber={SERVER_ADDRESS}");

        File.WriteAllText(pbkFile, sb.ToString(), Encoding.UTF8);

        return File.Exists(pbkFile);
    }
}
