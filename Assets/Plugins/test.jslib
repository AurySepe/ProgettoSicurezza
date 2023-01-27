// test.jslib

mergeInto(LibraryManager.library, {
    Test: function () {
        UnityInstance.SendMessage('RequestHandler', 'DoAction', 0);
      },
    
    SendRequest: function (requestJson)
     {
         let request = JSON.parse( UTF8ToString(requestJson) );
         console.log("Questa è la richiesta ricevuta: " + JSON.stringify(request));
         let requestFunction = RequestRouter[request.Uri];
         let input;
         if (request.Data !== undefined)
         {
              input = JSON.parse(request.Data);
         }
         requestFunction(input).then((value) =>
         {
             let response = {"RequestId" : request.RequestId,"Ok" : true,"Result" : JSON.stringify(value)};
             SendResponse(JSON.stringify(response));
     
         }).
         catch((error) =>
         {
             console.log("errore rilevato: " + JSON.stringify(error));
             let response = {"RequestId" : request.RequestId,"Ok" : false,"Result" : error.code + ""};
             SendResponse(JSON.stringify(response));
         })
     },

});