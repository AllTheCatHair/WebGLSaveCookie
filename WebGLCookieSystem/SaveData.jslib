 ///  存cookie脚本
 mergeInto(LibraryManager.library, {


  Save: function (key,jsonString,days) {

    console.log(key);
    console.log(jsonString);
    console.log(days);


    var name = UTF8ToString(key);
    var data = UTF8ToString(jsonString);

    console.log(name);
    console.log(data);

    let expires = "";
    if(days){
        let date = new Date();
        date.setTime(date.getTime() + (days*24*60*60*1000));
        expires = ";expires="+date.toUTCString();
    }

    document.cookie = name + "="+encodeURIComponent(data)+expires+";path=/";

    var returnStr = "保存成功";

    var bufferSize = lengthBytesUTF8(returnStr)+1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);

    return buffer;
  },
});
