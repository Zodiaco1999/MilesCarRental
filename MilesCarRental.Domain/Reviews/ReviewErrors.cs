using MilesCarRental.Domain.Abstractions;

namespace MilesCarRental.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new(
        "Review.NotEligible",
        "El alquiler no es elegible para dejar un review."
    );

}
