using System.Collections.Immutable;

namespace Day11;

public static class Solver {
    public static long GetPathsCount(Device device, ImmutableList<string> mustBeInPath) {
        var cache = new Dictionary<(string DeviceId, ImmutableList<string> MustBeInPath), long>(new CacheKeyComparer());
        
        return GetPathsCountCore(device, mustBeInPath, cache);
        
        static long GetPathsCountCore(Device device, ImmutableList<string> mustBeInPath, IDictionary<(string DeviceId, ImmutableList<string> MustBeInPath), long> cache) {
            const string terminalDevice = "out";

            if (cache.TryGetValue((device.Id, mustBeInPath), out var cacheValue)) {
                return cacheValue;
            }
            
            if (device.Id == terminalDevice) {
                return mustBeInPath.IsEmpty ? 1 : 0;
            }

            var count = device.Links.Sum(d => GetPathsCountCore(d, mustBeInPath.Remove(device.Id), cache));
            
            cache.Add((device.Id, mustBeInPath), count);

            return count;
        }
    }
    
    private class CacheKeyComparer : IEqualityComparer<(string DeviceId, ImmutableList<string> MustBeInPath)> {
        public bool Equals((string DeviceId, ImmutableList<string> MustBeInPath) x, (string DeviceId, ImmutableList<string> MustBeInPath) y) {
            return x.DeviceId == y.DeviceId 
                   && x.MustBeInPath.Count == y.MustBeInPath.Count
                   && x.MustBeInPath.All(y.MustBeInPath.Contains);
        }

        public int GetHashCode((string DeviceId, ImmutableList<string> MustBeInPath) obj) {
            return obj.DeviceId.GetHashCode();
        }
    }
}