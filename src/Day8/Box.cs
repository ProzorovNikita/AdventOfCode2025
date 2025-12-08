namespace Day8;

public sealed record Box(int X, int Y, int Z) {
    public int Circuit { get; set; }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y, Z);
    }

    public bool Equals(Box? other) {
        if (other  is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return X == other.X && Y == other.Y && Z == other.Z;
    }
}