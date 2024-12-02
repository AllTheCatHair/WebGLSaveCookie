// javascript_extend.jslib

mergeInto(LibraryManager.library, {
  // this is you code
  showDialog: function (str) {
    // var data = Pointer_stringify(str);
    var data = UTF8ToString(str);
    console.log("Console");
    console.log("data");
    // '__UnityLib__' is a global function collection.
    __UnityLib__.hsGetGameData(data);
  },
  
  Hello: function () {
    window.alert("Hello, world!");
  }
});