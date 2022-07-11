using SigmaCamp_HomeTask13;

public delegate void CheckoutCoordHandler(object sender, CheckoutCoordEventArgs e);
public class CheckoutCoordEventArgs:CheckoutEventArgs
{
    public Checkout Checkout { get; private set; }
    public CheckoutCoordEventArgs(string someMessage, Checkout checkout):base(someMessage)
    {
        this.Checkout = checkout;
    }
}