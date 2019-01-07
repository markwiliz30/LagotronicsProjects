using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCallBack.ConverterClasses
{
    public class ConvertManager
    {
        public ConvertItem convertToItem(byte[] data)
        {
            var myItem = new ConvertItem();
            int i = 0;
            byte[] _buffer;
            byte[] id;
            byte[] user;
            byte[] score;
            byte[] date;
            byte[] time;
            byte[] appName;

            for (int a = 0; a <= data.Length - 1; a++)
            {
                if (data[a] == 38)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 38)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    id = new byte[i];
                    Array.Copy(_buffer, id, i);
                    i = 0;
                    a++;
                    myItem.rfId = Encoding.ASCII.GetString(id);
                }
                if (data[a] == 42)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 42)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    user = new byte[i];
                    Array.Copy(_buffer, user, i);
                    i = 0;
                    a++;
                    myItem.name = Encoding.ASCII.GetString(user);
                }
                if (data[a] == 36)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 36)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    score = new byte[i];
                    Array.Copy(_buffer, score, i);
                    i = 0;
                    a++;
                    myItem.score = Encoding.ASCII.GetString(score);
                }
                if (data[a] == 37)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 37)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    date = new byte[i];
                    Array.Copy(_buffer, date, i);
                    i = 0;
                    a++;
                    myItem.date = Encoding.ASCII.GetString(date);
                }
                if (data[a] == 94)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 94)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    time = new byte[i];
                    Array.Copy(_buffer, time, i);
                    i = 0;
                    a++;
                    myItem.time = Encoding.ASCII.GetString(time);
                }
                if (data[a] == 35)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 35)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    appName = new byte[i];
                    Array.Copy(_buffer, appName, i);
                    i = 0;
                    a++;
                    myItem.appName = Encoding.ASCII.GetString(appName);
                }
            }
            return myItem;
        }
        public ConvertItem UpdateItem(byte[] data)
        {
            var myItem = new ConvertItem();
            int i = 0;
            byte[] _buffer;
            byte[] id;
            byte[] points;
            byte[] balance;

            for (int a = 1; a <= data.Length - 1; a++)
            {
                if (data[a] == 126)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 126)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    id = new byte[i];
                    Array.Copy(_buffer, id, i);
                    i = 0;
                    a++;
                    myItem.rfId = Encoding.ASCII.GetString(id);
                }
                if (data[a] == 33)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 33)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    points = new byte[i];
                    Array.Copy(_buffer, points, i);
                    i = 0;
                    a++;
                    myItem.points = Encoding.ASCII.GetString(points);
                }
                if (data[a] == 64)
                {
                    _buffer = new byte[1024];
                    a++;
                    while (data[a] != 64)
                    {
                        _buffer[i] = data[a];
                        a++;
                        i++;
                    }
                    balance = new byte[i];
                    Array.Copy(_buffer, balance, i);
                    i = 0;
                    a++;
                    myItem.balance = Encoding.ASCII.GetString(balance);
                }
            }
            return myItem;
        }
    }
}
