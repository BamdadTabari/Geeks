namespace Dayana.Shared.Basic.MethodsAndObjects.BaseServices.ServiceBus.Rpc.Identity.Sample;

public class SampleBusResponseWithCustomError : BusResponse
{
    public string Text { get; set; }
    public new CustomError Error { get; set; }

    public override bool HasError()
    {
        if (Error != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}