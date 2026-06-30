namespace SharedContracts;

public record Order(Guid Id, string Item, int Quantity);
public record Payment(Guid OrderId, bool Success);