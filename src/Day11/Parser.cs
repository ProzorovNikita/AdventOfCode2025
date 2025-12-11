namespace Day11;

public static class Parser {
    public static Dictionary<string, Device> GetInput(IEnumerable<string> lines) {
        Dictionary<string, Device> devices = [];
        foreach (var line in lines) {
            ParseLine(line);
        }

        return devices;

        Device ParseLine(string line) {
            var split = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (!devices.TryGetValue(split[0], out var leftDevice)) {
                leftDevice = new Device(split[0]);
                devices.Add(leftDevice.Id, leftDevice);
            }
            
            var linkIds = split[1].Split(' ',  StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var linkId in linkIds) {
                if (!devices.TryGetValue(linkId, out var linkDevice)) {
                    linkDevice = new Device(linkId);
                    devices.Add(linkDevice.Id, linkDevice);
                }
                leftDevice.Links.Add(linkDevice);
            }

            return leftDevice;
        }
    }
}