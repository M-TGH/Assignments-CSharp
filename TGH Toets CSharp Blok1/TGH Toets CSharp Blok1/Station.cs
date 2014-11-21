using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGH_Toets_CSharp_Blok1
{
    class Station
    {
        //Properties:
        private String[] data;
        private String stationname, code, path;

        //Constructor:
        public Station(String _stationname, String _code, String _path)
        {
            stationname = _stationname;
            code = _code;
            path = _path;
        }

        //Getters and setters (only the ones needed):
        public String[] getData()
        {
            return data;
        }

        public String getStationName()
        {
            return stationname;
        }

        public String getCode()
        {
            return code;
        }

        public String getPath()
        {
            return path;
        }

        public void setData(String[] _data)
        {
            data = _data;
        }
    }
}
