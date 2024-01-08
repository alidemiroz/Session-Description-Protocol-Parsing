
class Program
{
    static void Main()
    {
        try
        {
            SDP sdp = new SDP();

            var lines = File.ReadAllLines("//Users//mehmetalingu//Desktop//sdp_input.txt");

            List<List<string>> sdpAll = new List<List<string>>();

            foreach (var line in lines)
            {
                if (line != "")
                {
                    sdp.sdpLines.Add(line);
                    switch (line[0])
                    {
                        case 'v': sdp.ProtocolVersion = string.Concat(line[2]); break;
                        case 'o':
                            string ownerdescp = line.Substring(2);

                            string[] ownerDatas = ownerdescp.Split(' ');
                            sdp.Owner.Username = ownerDatas[1];
                            sdp.Owner.SessionID = ownerDatas[2];
                            sdp.Owner.Version = ownerDatas[3];
                            sdp.Owner.NetworkType = ownerDatas[4];
                            sdp.Owner.AdressType = ownerDatas[5];
                            break;
                        case 's':
                            string namediscp = line.Substring(2);
                            sdp.SessionName = namediscp;
                            break;
                        case 'i':
                            string infodiscp = line.Substring(2);
                            sdp.SessionInfo = infodiscp;
                            break;
                        case 'u':
                            string uridiscp = line.Substring(2);
                            sdp.UriDescp = uridiscp;
                            break;
                        case 'e':
                            string maildiscp = line.Substring(2);
                            sdp.Email = maildiscp;
                            break;
                        case 'p':
                            string phonediscp = line.Substring(2);
                            sdp.Phone = phonediscp;
                            break;
                        case 'c':
                            string connectdescp = line.Substring(2);

                            string[] connectDatas = connectdescp.Split(' ');
                            sdp.Connection.NetworkType = connectDatas[0];
                            sdp.Connection.AdressType = connectDatas[1];
                            sdp.Connection.ConnectionAdress = connectDatas[2];
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    sdpAll.Add(sdp.sdpLines);
                    sdp = new SDP();
                }
            }

            

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

class SDP
{
    public List<string> sdpLines = new List<string>();
    public string ProtocolVersion { get; set; }
    public Owner Owner { get; set; } = new Owner();
    public string SessionName { get; set; }
    public string SessionInfo { get; set; }
    public string UriDescp { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Connection Connection { get; set; } = new Connection();
    public string BandwidthInfo { get; set; }
    public string TimeZoneAdjustments { get; set; }
    public string EncryptiontyKey { get; set; }
    public string SessionAttribute { get; set; }
    public string MyProperty { get; set; }
}

class Owner
{
    public string Username { get; set; }
    public string SessionID { get; set; }
    public string Version { get; set; }
    public string NetworkType { get; set; }
    public string AdressType { get; set; }
}

class Connection
{
    public string NetworkType { get; set; }
    public string AdressType { get; set; }
    public string ConnectionAdress { get; set; }
}