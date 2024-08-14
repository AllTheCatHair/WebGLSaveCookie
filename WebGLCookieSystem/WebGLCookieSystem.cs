using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public static class WebGLCookieSystem
{
    [DllImport("__Internal")]
    private static extern string Save(string key, string jsonString, int days);

    [DllImport("__Internal")]
    private static extern string Load(string key);
    /// <summary>
    /// 保存字符串到cookie
    /// </summary>
    /// <param name="key"></param>
    /// <param name="jsonString"></param>
    /// <param name="days"></param>
    public static void SaveToCookie(string key, string jsonString, int days)
    {
        byte[] datas = Encoding.UTF8.GetBytes(jsonString);
        jsonString = Convert.ToBase64String(datas);
        string message = Save(key, jsonString, days);
    }
    /// <summary>
    /// 保存json到cookie
    /// </summary>
    /// <param name="key"></param>
    /// <param name="jsonString"></param>
    /// <param name="days"></param>
    public static void SaveJsonToCookie(string key, string jsonString, int days)
    {
        while ((jsonString.Length % 3) != 0)
        {
            jsonString = jsonString + "a";
        }
        byte[] datas = Encoding.UTF8.GetBytes(jsonString);
        jsonString = Convert.ToBase64String(datas);
        string message = Save(key, jsonString, days);
    }
    /// <summary>
    /// 读取字符串从cookie
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string LoadFromCookie(string key)
    {
        string jsonString = Load(key); 
        byte[] datas = Convert.FromBase64String(jsonString);
        jsonString = Encoding.UTF8.GetString(datas);
        return jsonString;
    }
    /// <summary>
    /// 读取json从cookie
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string LoadJsonFromCookie(string key)
    {
        string jsonString = Load(key);
        byte[] datas = Convert.FromBase64String(jsonString);
        jsonString = Encoding.UTF8.GetString(datas);
        while (jsonString[jsonString.Length - 1] == 'a')
        {
            jsonString = jsonString.Substring(0, jsonString.Length - 1);
        }
        return jsonString;
    }







    /// <summary>
    /// string和二进制互转
    /// </summary>
    /// <param name="byteArray"></param>
    /// <returns></returns>
    public static string ByteArrayToBinaryString(byte[] byteArray)
    {
        return string.Join(string.Empty, byteArray.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
    }
    public static byte[] BinaryStringToByteArray(string binaryString)
    {
        int numOfBytes = binaryString.Length / 8;
        byte[] bytes = new byte[numOfBytes];

        for (int i = 0; i < numOfBytes; i++)
        {
            string byteString = binaryString.Substring(8 * i, 8);
            bytes[i] = Convert.ToByte(byteString, 2);
        }

        return bytes;
    }


}
