namespace GoatOrNot.Models
{
    /// <summary>
    ///  The model representing a quote.
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// The unique quote id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The quote.
        /// </summary>
        public string Value { get; set; }
    }
}