namespace OrderService.Communication.Sender
{
    public interface IOrderSender
    {
        public void SendOrderPositionsInfo(List<Tuple<int, int>> positions);
    }
}
