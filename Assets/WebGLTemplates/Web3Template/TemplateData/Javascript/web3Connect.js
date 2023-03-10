

let UnityInstance;


function startGame()
{
	var buildUrl = "Build";
      var loaderUrl = buildUrl + "/{{{ LOADER_FILENAME }}}";
      var config = {
        dataUrl: buildUrl + "/{{{ DATA_FILENAME }}}",
        frameworkUrl: buildUrl + "/{{{ FRAMEWORK_FILENAME }}}",
        codeUrl: buildUrl + "/{{{ CODE_FILENAME }}}",
#if MEMORY_FILENAME
        memoryUrl: buildUrl + "/{{{ MEMORY_FILENAME }}}",
#endif
#if SYMBOLS_FILENAME
        symbolsUrl: buildUrl + "/{{{ SYMBOLS_FILENAME }}}",
#endif
        streamingAssetsUrl: "StreamingAssets",
        companyName: "{{{ COMPANY_NAME }}}",
        productName: "{{{ PRODUCT_NAME }}}",
        productVersion: "{{{ PRODUCT_VERSION }}}",
      };

      var container = document.querySelector("#unity-container");
      var canvas = document.querySelector("#unity-canvas");
      //var loadingBar = document.querySelector("#unity-loading-bar");
      //var progressBarFull = document.querySelector("#unity-progress-bar-full");
      //var fullscreenButton = document.querySelector("#unity-fullscreen-button");
      //var mobileWarning = document.querySelector("#unity-mobile-warning");

      // By default Unity keeps WebGL canvas render target size matched with
      // the DOM size of the canvas element (scaled by window.devicePixelRatio)
      // Set this to false if you want to decouple this synchronization from
      // happening inside the engine, and you would instead like to size up
      // the canvas DOM size and WebGL render target sizes yourself.
      //config.matchWebGLToCanvasSize = false;

      if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
        container.className = "unity-mobile";
        // Avoid draining fillrate performance on mobile devices,
        // and default/override low DPI mode on mobile browsers.
        config.devicePixelRatio = 1;
        //mobileWarning.style.display = "block";
        setTimeout(() => {
          //mobileWarning.style.display = "none";
        }, 5000);
      } else {
        canvas.style.width = "95%";
        canvas.style.height = "95%";
      }
#if BACKGROUND_FILENAME
      canvas.style.background = "url('" + buildUrl + "/{{{ BACKGROUND_FILENAME.replace(/'/g, '%27') }}}') center / cover";
#endif
      //loadingBar.style.display = "block";

      var script = document.createElement("script");
      script.src = loaderUrl;
      script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
          //progressBarFull.style.width = 100 * progress + "%";
        }).then((unityInstance) => {
            UnityInstance = unityInstance;
          //loadingBar.style.display = "none";
          //fullscreenButton.onclick = () => {
            //unityInstance.SetFullscreen(1);
          //};
        }).catch((message) => {
          alert(message);
        });
      };
      document.body.appendChild(script);
}