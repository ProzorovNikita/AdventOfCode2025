namespace Day5;

public class Range {
    public long From { get; private set; }
    public long To { get; private set; }

    public Range(long from, long to) {
        From = from;
        To = to;
    }

    public bool IsInRange(long number) {
        return number >= From && number <= To;
    }

    public bool TryAddRange(Range other) {
        if (this.To < other.From || this.From > this.To) {
            return false;
        }
        
        From = Math.Min(this.From,  other.From);
        To = Math.Max(this.To,  other.To);

        return true;
    }

    public long CountIds() {
        return To - From + 1;
    }
}