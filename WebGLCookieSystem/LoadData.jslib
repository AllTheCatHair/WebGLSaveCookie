 ///  取cookie脚本
 mergeInto(LibraryManager.library, {


  Load: function (key) {

    var name = UTF8ToString(key);
    console.log(name);

    let nameEQ = name + "=";
    let cookies = document.cookie.split(';');
    for (let i = 0; i < cookies.length; i++) {
        let cookie = cookies[i].trim();
        if (cookie.indexOf(nameEQ) === 0) {

            var returnStr = cookie.substring(nameEQ.length, cookie.length);

            console.log(returnStr);
            var bufferSize = lengthBytesUTF8(returnStr)+1;
            var buffer = _malloc(bufferSize);

            stringToUTF8(returnStr,buffer,bufferSize);
            console.log("return");
            console.log(buffer);
            return buffer;
            
        }
    }
    return null;
  },
});
