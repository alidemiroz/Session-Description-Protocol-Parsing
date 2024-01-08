
class Program
{
    static void Main()
    {
        try
        {
            SDP sdp = new SDP();

            var lines = File.ReadAllLines("//Users//mehmetalingu//Desktop//sdp_input.txt");

            List<SDP> sdpAll = new List<SDP>();

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
                        case 'b':
                            string banddescp = line.Substring(2);

                            string[] bandDatas = banddescp.Split(':');
                            sdp.Bandwidth.Modifier = bandDatas[0];
                            sdp.Bandwidth.Value = bandDatas[1];
                            break;
                        case 't':
                            string timedescp = line.Substring(2);

                            string[] timeDatas = timedescp.Split(' ');
                            sdp.TimeZone.StartTime = timeDatas[0];
                            sdp.TimeZone.EndTime = timeDatas[1];
                            break;
                        case 'm':
                            string mediadescp = line.Substring(2);

                            string[] mediaDatas = mediadescp.Split(' ');
                            sdp.Media.Type = mediaDatas[0];
                            sdp.Media.PortNumber = mediaDatas[1];
                            sdp.Media.Transport = mediaDatas[2];
                            sdp.Media.Format.AddRange(mediaDatas.Skip(3));
                            break;
                        case 'a':
                            string attribute = line.Substring(2);

                            string[] attributeDatas = attribute.Split(' ');
                            sdp.Attribute.AddRange(attributeDatas);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    sdpAll.Add(sdp);
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
    public Bandwith Bandwidth { get; set; } = new Bandwith();
    public TimeZone TimeZone { get; set; } = new TimeZone();
    public Media Media { get; set; } = new Media();
    public List<string> Attribute { get; set; } = new List<string>();
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

class Bandwith
{
    public string Modifier { get; set; }
    public string Value { get; set; }
}

class TimeZone
{
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

class Media
{
    public string Type { get; set; }
    public string PortNumber { get; set; }
    public string Transport { get; set; }
    public List<string> Format { get; set; } = new List<string>();
}
