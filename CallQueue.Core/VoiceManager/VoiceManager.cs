using SQLHelper;
using System;
using System.Data;
using System.Diagnostics;

namespace CallQueue.Core
{
    public class VoiceManager
    {
        readonly ISQLHelper sqlHelper;

        public VoiceManager(ISQLHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public VoiceParameter GetVoiceParameter(string query = "select EnableCallVoice, CallVoiceContent, AllowPlayStartSound from common")
        {
            VoiceParameter voiceParameter = new VoiceParameter();
            try
            {
                DataTable dt = sqlHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    voiceParameter.AllowPlayStartSound = bool.Parse(dt.Rows[0]["AllowPlayStartSound"].ToString());
                    voiceParameter.Enabled = bool.Parse(dt.Rows[0]["EnableCallVoice"].ToString());
                    voiceParameter.CallVoiceContent = dt.Rows[0]["CallVoiceContent"].ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return voiceParameter;
        }

        public int SetVoiceParameter(VoiceParameter voiceParam, string query = "update common set EnableCallVoice = '{0}', CallVoiceContent = '{1}', AllowPlayStartSound = '{2}'")
        {
            if (voiceParam == null)
                return 0;

            return sqlHelper.ExecuteNonQuery(string.Format(query, voiceParam.Enabled, voiceParam.CallVoiceContent, voiceParam.AllowPlayStartSound));
        }
    }
}
