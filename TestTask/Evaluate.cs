namespace Packt.Shared;

public class Evaluate
{
    // A method for evaluate string expression
    public static long GetEvaluate(string expression)
    {
        try
        {
            System.Data.DataTable table = new();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return long.Parse((string)row["expression"]);
        }
        catch (OverflowException)
        {
            throw new OverflowException("Number is too large");
        }

    }
}
