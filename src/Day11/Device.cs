namespace Day11;

public class Device {
    public string Id { get; init; }
    public List<Device> Links { get; init; } = [];

    public Device(string id) {
        Id = id;
    }

    public override string ToString() {
        return $"{Id} -> {string.Join(",", Links.Select(d => d.Id))}";
    }
}