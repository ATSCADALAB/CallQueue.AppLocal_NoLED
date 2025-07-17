using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;

namespace CallQueue.Core
{
    public class ModbusManager
    {
        ISQLHelper sqlHelper;

        public ModbusManager(ISQLHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public List<ModbusMasterParameter> GetAllModbusMasterParameters(string query = "select * from modbus")
        {
            List<ModbusMasterParameter> modbusParameters = new List<ModbusMasterParameter>();
            DataTable dt = new DataTable();
            dt = sqlHelper.ExecuteQuery(query);
            return dt.ToObjects<ModbusMasterParameter>();
        }

        public int DeleteModbusMasterParameter(int id)
        {
            return sqlHelper.ExecuteNonQuery($"delete from modbus where Id = {id}");
        }

        public int UpdateModbusMasterParameter(ModbusMasterParameter parameter)
        {
            string query = $"update modbus set Name = '{parameter.Name}', Port = '{parameter.Port}', Baudrate = '{parameter.Baudrate}', " +
                $"Parity = '{parameter.Parity}', StopBits = '{parameter.StopBits}', DataBits = '{parameter.DataBits}' where Id = {parameter.Id}";
            return sqlHelper.ExecuteNonQuery(query);
        }

        public int InsertModbusMasterParameter(ModbusMasterParameter parameter)
        {
            string query = $"insert into modbus (Name, Port, Baudrate, Parity, StopBits, DataBits) values " +
                $"('{parameter.Name}', '{parameter.Port}', {parameter.Baudrate}, '{parameter.Parity}', '{parameter.StopBits}', {parameter.DataBits})";
            return sqlHelper.ExecuteNonQuery(query);
        }

        public static List<string> GetStopBits()
        {
            var result = Enum.GetNames(typeof(StopBits)).ToList();
            result.RemoveAt(0); //Remove 'None'
            result.RemoveAt(2); //Remove 'One Point Five'
            return result;
        }

        public static List<string> GetParities()
        {
            return Enum.GetNames(typeof(Parity)).ToList();
        }

        public static List<string> GetDatabits()
        {
            return new List<string>() { "7", "8" };
        }

        public static List<string> GetBaudrates()
        {
            return new List<string>() { "9600" };
        }

        public static List<string> GetPortNames()
        {
            return SerialPort.GetPortNames().ToList();
        }
    }
}
