using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.Utils;
using MarketClient.PL_BL;

namespace MarketClient.BL
{
    public interface ICommunicator
    {

        /// <summary>
        /// Send a buy request to the market server
        /// </summary>
        /// <param name="price">price for the item</param>
        /// <param name="commodity">id of the item</param>
        /// <param name="amount">amount to buy</param>
        /// <returns>the buy request id</returns>
        /// <exception cref="MarketException">error is throw in case of invalid request or invalid parameter.</exception>
        IMarketResponse SendBuyRequest(int price, int commodity, int amount);

        /// <summary>
        /// Send a sell request to the market server
        /// </summary>
        /// <param name="price">price for the item</param>
        /// <param name="commodity">id of the item</param>
        /// <param name="amount">amount to sell</param>
        /// <returns>the sell request id</returns>
        /// <exception cref="MarketException">error is throw in case of invalid request or invalid parameter.</exception>
        IMarketResponse SendSellRequest(int price, int commodity, int amount);

        /// <summary>
        /// Query the server about a sell/buy request.
        /// </summary>
        /// <param name="id">id of the request</param>
        /// <returns>data about that request.</returns>
        /// <exception cref="MarketException">error is throw in case of invalid request or invalid parameter.</exception>
        IMarketResponse SendQueryBuySellRequest(int id);

        /// <summary>
        /// Query the server about the market state of a the login user.
        /// </summary>
        /// <returns>data about the state of the user</returns>
        /// <exception cref="MarketException">error is throw in case of invalid request or invalid parameter.</exception>
        IMarketResponse SendQueryUserRequest();

        /// <summary>
        /// Query the server about an item.
        /// </summary>
        /// <param name="commodity">id of the item</param>
        /// <returns>the highest bid and the lowest price for this item</returns>
        /// <exception cref="MarketException">error is throw in case of invalid request or invalid parameter.</exception>
        IMarketResponse SendQueryMarketRequest(int commodity);

        /// <summary>
        /// Cancel a buy/sell request.
        /// </summary>
        /// <param name="id">id of the request</param>
        /// <returns>true iff the request got canceled or error otherwise</returns>
        /// <exception cref="MarketException">error is throw in case of invalid request or invalid parameter.</exception>
        IMarketResponse SendCancelBuySellRequest(int id);
    }



    public class Communicator
    {
        private SimpleHTTPClient client;
        private string url;
        private string user;
        private string token;

        public Communicator(string url, string user, string token)
        {
            this.url = url;
            this.user = user;
            this.token = token;
            this.client = new SimpleHTTPClient();
        }


        public IMarketResponse SendBuyRequest(int price, int commodity, int amount)
        {
            BuyRequest buyReq = new BuyRequest(commodity, amount, price); //create and define buy request
            MBuySell marketResponse = new MBuySell();

            try
            {
                marketResponse.id = client.SendPostRequest<BuyRequest>(url, user, token, buyReq);
            }
            catch (Exception e)
            {
                if (e is MarketException)
                    return (MarketException) e;
            }

            return marketResponse;
        }

        public IMarketResponse SendSellRequest(int price, int commodity, int amount)
        {
            SellRequest sellReq = new SellRequest(commodity, amount, price); //create and define sell request
            MBuySell marketResponse = new MBuySell();

            try
            {
                marketResponse.id = client.SendPostRequest<SellRequest>(url, user, token, sellReq);
            }
            catch (Exception e)
            {
                if (e is MarketException)
                    return (MarketException)e;
            }

            return marketResponse;

        }

        public IMarketResponse SendQueryBuySellRequest(int id)
        {
            QueryBuySellRequest queryBS = new QueryBuySellRequest(id); //create buy/sell query request
            MQReq marketResponse = new MQReq();

            try
            {
                marketResponse = client.SendPostRequest<QueryBuySellRequest, MQReq>(url, user, token, queryBS);
            }
            catch (Exception e)
            {
                if (e is MarketException)
                    return (MarketException)e;
            }

            return marketResponse;

        }

        public IMarketResponse SendQueryUserRequest()
        {
            QueryUserRequest userReq = new QueryUserRequest(); //create query user requset
            MQUser marketResponse = new MQUser();

            try
            {
                marketResponse = client.SendPostRequest<QueryUserRequest, MQUser>(url, user, token, userReq);
            }
            catch (Exception e)
            {
                if (e is MarketException)
                    return (MarketException)e;
            }

            return marketResponse;
        }

        public IMarketResponse SendQueryMarketRequest(int commodity)
        {
            QueryMarketRequest QMReq = new QueryMarketRequest(commodity); //create query market rquest
            MQCommodity marketResponse = new MQCommodity();

            try
            {
                marketResponse = client.SendPostRequest<QueryMarketRequest, MQCommodity>(url, user, token, QMReq);
            }
            catch (Exception e)
            {
                if (e is MarketException)
                    return (MarketException)e;
            }

            return marketResponse;
        }

        public IMarketResponse SendCancelBuySellRequest(int id)
        {
            CancelRequest cancelReq = new CancelRequest(id); //create cancel requst
            Mcancel marketResponse = new Mcancel();

            try
            {
                marketResponse.response = client.SendPostRequest<CancelRequest>(url, user, token, cancelReq);
            }
            catch (Exception e)
            {
                if (e is MarketException)
                    return (MarketException)e;
            }

            return marketResponse;
        }
    }
}
