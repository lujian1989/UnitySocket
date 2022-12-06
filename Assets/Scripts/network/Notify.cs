
namespace  network
{
    public abstract class Notify:Response
    {
        public override bool isNotify()
        {
            return true;
        }
    }

}
