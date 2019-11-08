﻿using System.Collections.Generic;
using YourCommonTools;

namespace YourBitcoinController
{

	public class BitcoinJSONFeeHTTP : BaseDataHTTP, IHTTPComms
	{
		private string m_urlRequest;

		private string m_currency;
		private string m_valueItem;


		public string UrlRequest
		{
			get { return m_urlRequest; }
		}

		public override Dictionary<string, string> GetHeaders()
		{
			Dictionary<string, string> headers = new Dictionary<string, string>();
			return headers;
		}

		public string Build(params object[] _list)
		{
			string phpFile = "^https://bitcoinfees.earn.com/api/v1/fees/recommended^";
#if !ENABLE_MY_OFUSCATION || UNITY_EDITOR
			phpFile = phpFile.Replace("^", "");
#endif
			m_urlRequest = phpFile;

			return "";
		}

		public override void Response(string _response)
		{
			ResponseCode(_response);

			BitcoinEventController.Instance.DispatchBitcoinEvent(BitCoinController.EVENT_BITCOINCONTROLLER_JSON_FEE_TABLE, m_jsonResponse);
		}
	}
}

