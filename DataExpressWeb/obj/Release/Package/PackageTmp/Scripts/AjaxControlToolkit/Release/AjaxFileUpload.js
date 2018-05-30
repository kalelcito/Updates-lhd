Type.registerNamespace("Sys.Extended.UI.AjaxFileUpload"),Sys.Extended.UI.AjaxFileUpload.Utils=function(){this.generateGuid=function(){var e,t,i;for(e="",i=0;i<32;i++)8!=i&&12!=i&&16!=i&&20!=i||(e+="-"),t=Math.floor(16*Math.random()).toString(16).toUpperCase(),e+=t;return e},this.getFileName=function(e){var t="";if(!e)return"";if(!e.value&&e.name)t=e.name;else{if(!e.value&&"string"!=typeof e)throw"Invalid parameter. fullPath parameter must be a string of full path or file element.";if(e.value&&(e=e.value),e){var i=e.indexOf("\\")>=0?e.lastIndexOf("\\"):e.lastIndexOf("/"),n=e.substring(i);0!==n.indexOf("\\")&&0!==n.indexOf("/")||(n=n.substring(1)),t=n}}return encodeURIComponent(t)},this.getFileType=function(e){if(!e)throw"file must defined or not null";if(!e.value&&e.name)return e.name.substring(e.name.lastIndexOf(".")+1);if(e.value&&(e=e.value),"string"!=typeof e)throw"can't resolve file type.";return e.substring(e.lastIndexOf(".")+1)},this.sizeToString=function(e){if(!e||e<=0)return"0 Kb";var t=["bytes","kb","MB","GB","TB","PB"],i=Math.floor(Math.log(e)/Math.log(1024));return(e/Math.pow(1024,Math.floor(i))).toFixed(2)+" "+t[i]},this.checkHtml5BrowserSupport=function(){return window.File&&window.FileReader&&window.FileList&&window.Blob&&(new XMLHttpRequest).upload}},Sys.Extended.UI.AjaxFileUpload.Item=function(e,t,i){this._deleteButton=null,this._parentId=e,this._inputElementValue=t.value,this._id=t.id,this._slices=t.slices,this._sliceIndex=0,this._fileInfoContainer=null,this._fileStatusText=null,this._isUploaded=!1,this._isUploading=!1,this._fileSize=0,this._fileName="",this._fileType="",this._bytesUploaded=0,this._ui=this.initUI(i)},Sys.Extended.UI.AjaxFileUpload.Item.prototype={initUI:function(e){var t=this,i=this._inputElementValue,n=new Sys.Extended.UI.AjaxFileUpload.Utils,l=n.checkHtml5BrowserSupport(),s=this._id,o=$common.createElementFromTemplate({nodeName:"div",properties:{id:this._parentId+"_FileItemContainer_"+s},cssClasses:["ajax__fileupload_fileItemInfo"]}),a=$common.createElementFromTemplate({nodeName:"div",properties:{id:this._parentId+"_FileInfoContainer_"+s,style:{display:"inline-block"}}}),r=$common.createElementFromTemplate({nodeName:"span",properties:{id:this._parentId+"_FileItemInfo_"+s},cssClasses:["ajax__fileupload_fileItemInfo"]}),d=$common.createElementFromTemplate({nodeName:"span",properties:{id:this._parentId+"_FileItemStatus_"+s},cssClasses:["uploadstatus"]}),u=$common.createElementFromTemplate({nodeName:"div",properties:{id:this._parentId+"_FileItemDeleteButton_"+s},cssClasses:["removeButton"]});this._fileName=n.getFileName(i);var p=decodeURIComponent(this._fileName);if(l){this._fileSize=i.size;var c=i.type?'<span class="filetype">('+i.type+")</span>":"";r.innerHTML='<span class="filename">'+p+"</span> "+c+' - <span class="filesize">'+n.sizeToString(i.size)+"</span> ",this._fileType=i.type}else r.innerHTML='<span class="filename">'+p+"</span>",this._fileType=n.getFileType(i);return a.appendChild(r),a.appendChild(d),$common.setText(u,Sys.Extended.UI.Resources.AjaxFileUpload_Remove),$addHandlers(u,{click:Function.createDelegate(this,function(){e(t)})}),Sys.Browser.agent==Sys.Browser.InternetExplorer&&Sys.Browser.version<=8?(o.appendChild(u),o.appendChild(a)):(o.appendChild(a),o.appendChild(u)),this._fileInfoContainer=a,this._deleteButton=u,this._fileStatusText=d,o},setStatus:function(e,t){$common.setText(this._fileStatusText," ("+t+")"),this._fileInfoContainer.setAttribute("class",e+"State")},disabled:function(e){e?this._deleteButton.disabled="disabled":this._deleteButton.disabled=""},hide:function(){this._deleteButton.style.visibility="hidden"},destroy:function(){$common.removeElement(this._inputElementValue),$common.removeElement(this._deleteButton),$common.removeElement(this._ui)},get_inputElementValue:function(){return this._inputElementValue},appendNodeTo:function(e){e.appendChild(this._ui)},removeNodeFrom:function(e){e.removeChild(this._ui)}},Sys.Extended.UI.AjaxFileUpload.Processor=function(e,t){var i=new Sys.Extended.UI.AjaxFileUpload.Utils,n=new XMLHttpRequest;this._iframe=null,this._iframeName=e.get_id()+"_uploadIframe",this._form=null,this.initialize=function(){this.attachEvents(),this.createIFrame(),this.createForm()},this.attachEvents=function(){this.onFileSelected$delegate=Function.createDelegate(this,this.onFileSelectedHandler),this.attachFileInputEvents(t.inputFile,!0);var i=this;n.onreadystatechange=function(t){if(4==n.readyState&&200==n.status){var l=n.responseText;l&&(l=parseFloat(l).toFixed(2),e.setPercent(l)),l<100&&setTimeout(function(){i.pollingServerProgress(!0)},500)}}},this.attachFileInputEvents=function(e,t){t?$addHandlers(e,{change:this.onFileSelected$delegate}):$common.removeHandlers(e,{change:this.onFileSelected$delegate})},this.onFileSelectedHandler=function(n){var l={id:i.generateGuid(),value:t.inputFile,type:i.getFileType(t.inputFile.value)};return e.fileTypeIsValid(l.type)?e.fileSizeExceeded(l.value.size)?void e.confirmFileIsTooLarge(l):(e.addFileToQueue(l),void this.createInputFileElement()):void e.confirmFileIsInvalid(l)},this.createInputFileElement=function(){var n=t.inputFile;n.style.zIndex=-999,$common.setLocation(n,{x:-99999,y:-99999}),this.attachFileInputEvents(n,!1);var l=e.get_id()+"_file_"+i.generateGuid(),s=$common.createElementFromTemplate({nodeName:"input",properties:{id:l,name:"act-file-data",type:"file",style:{zIndex:0,cursor:"pointer",position:"absolute"},multiple:!0}},n.parentNode);$common.setElementOpacity(s,0),this.attachFileInputEvents(s,!0),t.inputFile=s},this.startUpload=function(){var t=this._form,i=e.getNextFile();if(!i)return e._currentFileId=null,this.setThrobber(!1),void e.done();e.setAsUploading(i);var n=i.get_inputElementValue();for(e._currentFileId=i._id,this.setThrobber(!0);t.firstChild;)t.removeChild(t.firstChild);n.name="act-file-data",t.appendChild(n),t.setAttribute("action",e.get_uploadHandlerPath()+"?contextKey="+e.get_contextKey()+"&controlID="+e.get_id()+"&fileId="+e._currentFileId+"&fileName="+i._fileName+"&usePoll="+(e.get_serverPollingSupport()?"true":"false")),t.submit()},this.cancelUpload=function(){var t=new XMLHttpRequest,i=this;n&&n.abort(),t.open("POST","?contextKey="+e.get_contextKey()+"&controlID="+e.get_id()+"&cancel=1&guid="+e._currentFileId+i.getQueryString(),!0),t.onreadystatechange=function(){if(i.setThrobber(!1),4==t.readyState){if(200!=t.status)throw i.raiseUploadError(t),"Failed to cancel upload.";e.cancelUpload()}},t.send(null)},this.getQueryString=function(){return"&"+window.location.search.replace("?","")},this.createIFrame=function(){var e=this._iframeName,t=document.createElement("IFRAME");t.width="0",t.height="0",t.style.display="none",t.src="about:blank",t.id=e,t.name=e,t.security="restricted",document.body.appendChild(t),t.contentWindow.name=e,$addHandlers(t,{load:Function.createDelegate(this,this.onIFrameLoadedHandler)}),this._iframe=t},this.onIFrameLoadedHandler=function(t){if(e._currentFileId)try{var i=this._iframe,n=null;if(i.contentDocument?n=i.contentDocument:i.contentWindow?n=i.contentWindow.document:i.document&&(n=i.document),null==n)throw"Document not initialized";e.doneAndUploadNextFile(e.getCurrentFileItem())}catch(t){if(!e._canceled||!t.message||!(t.message.indexOf("Access is denied")>-1||t.message.indexOf("Permission denied")>-1))throw this.raiseUploadError(t),t}},this.setThrobber=function(i){return e.get_serverPollingSupport()?(e.setPercent(0),$common.setVisible(t.progressBar,!!i),$common.setVisible(t.progressBarContainer,!!i),void this.pollingServerProgress(i)):void(null!=e.get_throbber()&&(e.get_throbber().style.display=i?"":"none"))},this.pollingServerProgress=function(t){t&&e._currentFileId&&(n.open("GET","?contextKey="+e.get_contextKey()+"&controlID="+e.get_id()+"&poll=1&guid="+e._currentFileId,!0),n.send(null))},this.createForm=function(){var t,i="___postForm"+e.get_id();try{t=document.createElement('<form method="post" enctype="multipart/form-data" id="'+i+'" target="'+this._iframeName+'">')}catch(e){t=document.createElement("form"),t.setAttribute("id",i),t.setAttribute("method","post"),t.setAttribute("target",this._iframe.id),t.setAttribute("enctype","multipart/form-data")}t.style.visibility="hidden",t.style.display="none",document.body.appendChild(t),this._form=t},this.raiseUploadError=function(t){e.raise_uploadError(t),n&&n.abort(),e._currentFileId=null},this.resetUI=function(){e.setFileStatus(e._currentFileId,"error",Sys.Extended.UI.Resources.AjaxFileUpload_error)}},Sys.Extended.UI.AjaxFileUpload.ProcessorHtml5=function(e,t){var i=new Sys.Extended.UI.AjaxFileUpload.Utils,n=1e3*e.get_chunkSize(),l=0,s=null;this.initialize=function(){$common.setVisible(t.dropZone,!0),t.dropZone.innerHTML=Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles,this.attachEvents()},this.attachEvents=function(){this.onFileDropped$delegate=Function.createDelegate(this,this.onFileDroppedHandler),this.onFileDragOver$delegate=Function.createDelegate(this,this.onFileDragOverHandler),this.onFileSelected$delegate=Function.createDelegate(this,this.onFileSelectedHandler),t.inputFile.addEventListener("change",this.onFileSelected$delegate,!1),t.dropZone.addEventListener("drop",this.onFileDropped$delegate,!1),t.dropZone.addEventListener("dragover",this.onFileDragOver$delegate,!1)},this.onFileDroppedHandler=function(t){t.stopPropagation(),t.preventDefault(),e.get_enabled()&&(this.addFilesToQueue(t.dataTransfer.files),e.get_autoStartUpload()&&e.startUpload())},this.onFileDragOverHandler=function(e){e.stopPropagation(),e.preventDefault()},this.onFileSelectedHandler=function(t){this.addFilesToQueue(t.target.files),this.createInputFileElement(),e.get_autoStartUpload()&&e.startUpload()},this.createInputFileElement=function(){var n=t.inputFile;delete n;var l=e.get_id()+"_file_"+i.generateGuid(),s=$common.createElementFromTemplate({nodeName:"input",properties:{id:l,name:"act-file-data",type:"file",style:{zIndex:0,cursor:"pointer",position:"absolute"},multiple:!0}},n.parentNode);$common.setElementOpacity(s,0),this.attachFileInputEvents(s,!0),t.inputFile=s},this.attachFileInputEvents=function(e,t){t?$addHandlers(e,{change:this.onFileSelected$delegate}):$common.removeHandlers(e,{change:this.onFileSelected$delegate})},this.addFilesToQueue=function(l){for(var s=0;s<l.length;s++){var o=l[s],a=0;o.size>n&&(a=Math.ceil(o.size/n));var r={id:i.generateGuid(),value:l[s],type:i.getFileType(l[s]),uploaded:!1,slices:a};if(e.fileTypeIsValid(r.type)){if(e.fileSizeExceeded(r.value.size))e.confirmFileIsTooLarge(r);else if(!e.addFileToQueue(r))break}else e.confirmFileIsInvalid(r)}t.inputFile.value=null},this.cancelUpload=function(){s&&s.abort(),e.cancelUpload()},this.startUpload=function(){var i=e.getNextFile();i?(0===i._sliceIndex&&e.setPercent(0),$common.setVisible(t.progressBarContainer,!0),this.upload(i)):(e._currentFileId=null,e.setPercent(0),$common.setVisible(t.progressBarContainer,!1),e.done())},this.resetUI=function(){$common.setVisible(t.progressBarContainer,!1),$common.setVisible(e._elements.uploadOrCancelButton,!1);var i=e.getNextFile();i._isUploaded=!0,i._isUploading=!1},this.upload=function(i){if(e._isUploading){$common.setVisible(t.progressBar,!0),e.setAsUploading(i);var l=i.get_inputElementValue(),s=i._fileName,o=i._slices&&i._slices>0,a=0==i._sliceIndex;if(o){var r=i._sliceIndex*n,d=r+n;l=l.slice(r,d>l.size?l.size:d)}var u=new FormData,p=e._currentFileId=i._id,c=new XMLHttpRequest,h=this,_=function(e){return function(t){e.call(h,p,t)}};c.upload.addEventListener("progress",_(this.onProgressHandler),!1),c.addEventListener("load",_(this.onUploadCompleteHandler),!1),c.addEventListener("error",_(this.onUploadFailedHandler),!1),c.addEventListener("abort",_(this.onUploadCanceledHandler),!1),c.open("POST",e.get_uploadHandlerPath()+"?contextKey="+e.get_contextKey()+"&controlID="+e.get_id()+"&fileId="+p+"&fileName="+s+"&chunked="+(o?"true":"false")+"&firstChunk="+a,!0),u.append("act-file-data",l),c.send(u)}},this.onProgressHandler=function(t,i){if(e._isUploading&&i.lengthComputable){l=i.loaded;var n=e.getFileItem(t),s=n._slices,o=n._bytesUploaded+l,a=s-n._sliceIndex==1?o:i.total*s,r=0==s?(100*i.loaded/i.total).toFixed(2):(o/a*100).toFixed(2);e.setPercent(r)}},this.onUploadCompleteHandler=function(t,n){var s=this,o=e.getFileItem(t),a=o.get_inputElementValue();o._slices&&o._slices>0&&o._sliceIndex+1<o._slices?(o._sliceIndex++,o._bytesUploaded+=l,l=0,s.startUpload()):(o.hide(),o.setStatus("uploaded",Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded),e.setStatusMessage(String.format(Sys.Extended.UI.Resources.AjaxFileUpload_UploadingHtml5File,a.name,i.sizeToString(a.size))),e.doneAndUploadNextFile(o))},this.onUploadFailedHandler=function(t,i){var n=e.getFileItem(t);n._isUploading=!1,e.setFileStatus(t,"error",Sys.Extended.UI.Resources.AjaxFileUpload_error),e.raise_uploadError(i)},this.onUploadCanceledHandler=function(t,i){var n=e.getFileItem(t);n._isUploading=!1,e.setFileStatus(n,"canceled",Sys.Extended.UI.Resources.AjaxFileUpload_Canceled)}},Sys.Extended.UI.AjaxFileUploadStartEventArgs=function(e,t){if(2!=arguments.length)throw Error.parameterCount();Sys.Extended.UI.AjaxFileUploadStartEventArgs.initializeBase(this),this._filesInQueue=e,this._serverArguments=t},Sys.Extended.UI.AjaxFileUploadStartEventArgs.prototype={get_filesInQueue:function(){return this._filesInQueue},get_serverArguments:function(){return this._serverArguments}},Sys.Extended.UI.AjaxFileUploadStartEventArgs.registerClass("Sys.Extended.UI.AjaxFileUploadStartEventArgs",Sys.EventArgs),Sys.Extended.UI.AjaxFileUploadEventArgs=function(e,t,i,n,l,s,o,a){if(8!=arguments.length)throw Error.parameterCount();Sys.Extended.UI.AjaxFileUploadEventArgs.initializeBase(this),this._fileId=e,this._statusMessage=t,this._fileName=i,this._fileSize=n,this._contentType=l,this._postedUrl=s,this._fileIndex=o,this._fileQueueLength=a},Sys.Extended.UI.AjaxFileUploadEventArgs.prototype={get_fileId:function(){return this._fileId},get_fileName:function(){return this._fileName},get_statusMessage:function(){return this._statusMessage},get_fileSize:function(){return this._fileSize},get_contentType:function(){return this._contentType},get_postedUrl:function(){return this._postedUrl},set_postedUrl:function(){return this._postedUrl=value},get_fileIndex:function(){return this._fileIndex},get_fileQueueLength:function(){return this._fileQueueLength}},Sys.Extended.UI.AjaxFileUploadEventArgs.registerClass("Sys.Extended.UI.AjaxFileUploadEventArgs",Sys.EventArgs),Sys.Extended.UI.AjaxFileUploadCompleteAllEventArgs=function(e,t,i,n){if(4!=arguments.length)throw Error.parameterCount();Sys.Extended.UI.AjaxFileUploadCompleteAllEventArgs.initializeBase(this),this._filesInQueue=e,this._filesUploaded=t,this._reason=i,this._serverArguments=n},Sys.Extended.UI.AjaxFileUploadCompleteAllEventArgs.prototype={get_filesInQueue:function(){return this._filesInQueue},get_reason:function(){return this._reason},get_filesUploaded:function(){return this._filesUploaded},get_serverArguments:function(){return this._serverArguments}},Sys.Extended.UI.AjaxFileUploadCompleteAllEventArgs.registerClass("Sys.Extended.UI.AjaxFileUploadCompleteAllEventArgs",Sys.EventArgs),Sys.Extended.UI.AjaxFileUpload.Control=function(e){Sys.Extended.UI.AjaxFileUpload.Control.initializeBase(this,[e]),this._contextKey=null,this._postBackUrl=null,this._mode=0,this._autoStartUpload=!1,this._serverPollingSupport=!1,this._throbber=null,this._maximumNumberOfFiles=10,this._allowedFileTypes="",this._chunkSize=4096,this._clearFileListAfterUpload=!1,this._useAbsoluteHandlerPath=!0,this._maxFileSize=0,this._uploadHandlerPath="",this._enabled=!0,this._useHtml5Support=!1,this._elements=null,this._processor=null,this._filesInQueue=[],this._isUploading=!1,this._currentFileId=null,this._currentQueueIndex=0,this._canceled=!1},Sys.Extended.UI.AjaxFileUpload.Control.prototype={initialize:function(){var e=new Sys.Extended.UI.AjaxFileUpload.Utils,t=this.get_id(),i=function(e){return document.getElementById(t+e)},n={queueContainer:i("_QueueContainer"),selectFileButton:i("_SelectFileButton"),uploadOrCancelButton:i("_UploadOrCancelButton"),fileStatusContainer:i("_FileStatusContainer"),footer:i("_Footer")};this._useHtml5Support=e.checkHtml5BrowserSupport()&&2!=this._mode,n.progressBar=i("_ProgressBar"),n.progressBarContainer=i("_ProgressBarContainer"),this._useHtml5Support?(n.inputFile=i("_Html5InputFile"),n.dropZone=i("_Html5DropZone")):n.inputFile=i("_InputFileElement"),this._elements=n;var l=this._useHtml5Support?new Sys.Extended.UI.AjaxFileUpload.ProcessorHtml5(this,n):new Sys.Extended.UI.AjaxFileUpload.Processor(this,n);this.setDefaultElementsLayout(n),this.attachEvents(n),l.initialize(),this._processor=l,Sys.Extended.UI.AjaxFileUpload.Control.callBaseMethod(this,"initialize")},dispose:function(){Sys.Extended.UI.AjaxFileUpload.Control.callBaseMethod(this,"dispose")},setDefaultElementsLayout:function(e){$common.setVisible(e.inputFile,!0),e.uploadOrCancelButton.style.visibility="hidden",$common.setVisible(e.fileStatusContainer,!0),e.selectFileButton.innerHTML=Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile,e.uploadOrCancelButton.innerHTML=Sys.Extended.UI.Resources.AjaxFileUpload_Upload,this.setStatusMessage(Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload)},attachEvents:function(e){this.onUploadOrCancelButtonClicked$delegate=Function.createDelegate(this,this._onUploadOrCancelButtonClickedHandler),$addHandlers(e.uploadOrCancelButton,{click:this.onUploadOrCancelButtonClicked$delegate})},onUploadOrCancelButtonClickedHandler:function(e){Sys.Extended.Deprecated("onUploadOrCancelButtonClickedHandler(e)")},_onUploadOrCancelButtonClickedHandler:function(e){var t=this._filesInQueue;if(this.validateFiles(t)){if(!t.length)return void alert(Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload);for(var i=0,n=0;n<t.length;n++)t[n]._isUploaded&&i++;if(i==t.length)return void alert(Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded);if(this.enableControls(this._isUploading),this._isUploading=!this._isUploading,this._isUploading){this._canceled=!1;var l=new XMLHttpRequest,s=this;l.open("POST","?contextKey="+this.get_contextKey()+"&controlID="+this.get_id()+"&start=1&queue="+this._filesInQueue.length+this.getQueryString()),l.onreadystatechange=function(){if(4==l.readyState){if(200!=l.status)throw s.raise_uploadError(l),s.setFileStatus(fileItem,"error",Sys.Extended.UI.Resources.AjaxFileUpload_error),"Failed to starting upload.";s._processor.startUpload(),s.raise_uploadStart(Sys.Serialization.JavaScriptSerializer.deserialize(l.responseText))}},l.send(null)}else{this._canceled=!0,this._processor.cancelUpload();for(var n=0;n<t.length;n++)t[n]._isUploaded||(t[n]._isUploading=!1)}}},validateFiles:function(e){return!0},startUpload:function(){!this._isUploading&&this._filesInQueue.length&&this._onUploadOrCancelButtonClickedHandler()},enableControls:function(e){var t=this._elements.uploadOrCancelButton;$common.setText(t,e?Sys.Extended.UI.Resources.AjaxFileUpload_Upload:Sys.Extended.UI.Resources.AjaxFileUpload_Cancel),t.setAttribute("class",e?"ajax__fileupload_uploadbutton":"ajax_fileupload_cancelbutton"),$common.setVisible(this._elements.inputFile,e),this._useHtml5Support&&(this._elements.dropZone.disable=!e,this._elements.inputFile.disable=!e)},done:function(){this._isUploading=!1,this.enableControls(!0),this.setStatusMessage(Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded+" "+Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload),$common.setVisible(this._elements.uploadOrCancelButton,!1);var e=new XMLHttpRequest,t=this,i=this._filesInQueue[this._currentQueueIndex-1];if(e.open("POST","?contextKey="+this.get_contextKey()+"&controlID="+this.get_id()+"&complete=1&queue="+this._filesInQueue.length+"&uploaded="+(this._currentQueueIndex-(i._isUploaded?0:1))+"&reason="+(this._canceled?"cancel":"done")+this.getQueryString()),e.onreadystatechange=function(){if(4==e.readyState){if(200!=e.status)throw t.raise_uploadError(e),t.setFileStatus(fileItem,"error",Sys.Extended.UI.Resources.AjaxFileUpload_error),"Failed to completing upload.";t.raise_uploadCompleteAll(Sys.Serialization.JavaScriptSerializer.deserialize(e.responseText))}},e.send(null),this.get_clearFileListAfterUpload()){for(var n=0;n<this._filesInQueue.length;n+=1){var l=this._filesInQueue[n];l.removeNodeFrom(this._elements.queueContainer)}$common.setVisible(this._elements.queueContainer,!1),$common.setVisible(this._elements.uploadOrCancelButton,!1)}this._filesInQueue=[],this._currentQueueIndex=0},removeFileFromQueueHandler:function(e){e&&!e._isUploading&&(Array.remove(this._filesInQueue,e),e.removeNodeFrom(this._elements.queueContainer),this._elements.queueContainer.hasChildNodes()||($common.setVisible(this._elements.queueContainer,!1),$common.setVisible(this._elements.uploadOrCancelButton,!1)),this._showFilesCount())},addFileToQueue:function(e){var t=this.get_maximumNumberOfFiles();if(t>0&&this._filesInQueue.length>=t)return alert(Sys.Extended.UI.Resources.AjaxFileUpload_MaxNumberOfFilesExceeded),!1;var i=new Sys.Extended.UI.AjaxFileUpload.Item(this.get_id(),e,Function.createDelegate(this,this.removeFileFromQueueHandler));return i.appendNodeTo(this._elements.queueContainer),i.setStatus("pending",Sys.Extended.UI.Resources.AjaxFileUpload_Pending),$common.setVisible(this._elements.queueContainer,!0),$common.setVisible(this._elements.uploadOrCancelButton,!0),this._filesInQueue.push(i),this._showFilesCount(),!0},_showFilesCount:function(){var e=0==this._filesInQueue.length;this.setStatusMessage(e?Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload:String.format(Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue,this._filesInQueue.length.toString()))},fileTypeIsValid:function(e){if(!this._allowedFileTypes)return!0;for(var t=this._allowedFileTypes.split(","),i=0;i<t.length;i++){var n=t[i];if(e.toLocaleLowerCase()==n.toLocaleLowerCase())return!0}return!1},fileSizeExceeded:function(e){return!(this.get_maxFileSize()<=0)&&e>this.getMaxFileSizeInBytes()},confirmFileIsInvalid:function(e){var t=new Sys.Extended.UI.AjaxFileUpload.Utils;alert(String.format(Sys.Extended.UI.Resources.AjaxFileUpload_WrongFileType,t.getFileName(e.value),e.type))},confirmFileIsTooLarge:function(e){var t=new Sys.Extended.UI.AjaxFileUpload.Utils;alert(String.format(Sys.Extended.UI.Resources.AjaxFileUpload_TooLargeFile,t.getFileName(e.value),this.get_maxFileSize()))},getMaxFileSizeInBytes:function(){return 1024*this.get_maxFileSize()},doneAndUploadNextFile:function(e){var t=new XMLHttpRequest,i=this;t.open("POST","?contextKey="+this.get_contextKey()+"&controlID="+this.get_id()+"&done=1&guid="+e._id+this.getQueryString(),!0),t.onreadystatechange=function(n){if(4==t.readyState){if(200!=t.status||""==t.responseText)throw i.setFileStatus(e,"error",Sys.Extended.UI.Resources.AjaxFileUpload_error),i.raise_uploadError(t),"error raising upload complete event and start new upload";i.raise_uploadComplete(Sys.Serialization.JavaScriptSerializer.deserialize(t.responseText)),i._processor.startUpload()}},t.send()},getQueryString:function(){return"&"+window.location.search.replace("?","")},cancelUpload:function(){var e=this.getCurrentFileItem();e._isUploaded=!1,e._isUploading=!1,this.setStatusMessage(Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled);for(var t=0;t<this._filesInQueue.length;t++){var i=this._filesInQueue[t];i._isUploaded||this.setFileStatus(i,"cancelled",Sys.Extended.UI.Resources.AjaxFileUpload_Canceled)}},setAsUploading:function(e){e._isUploading=!0,e._isUploaded=!1,this._currentQueueIndex=Array.indexOf(this._filesInQueue,e)+1,this.setFileStatus(e,"uploading",Sys.Extended.UI.Resources.AjaxFileUpload_Uploading),this.setStatusMessage(String.format(Sys.Extended.UI.Resources.AjaxFileUpload_UploadingFileInQueue,this._currentQueueIndex,this._filesInQueue.length))},setFileStatus:function(e,t,i){"string"==typeof e&&(e=this.getFileItem(e)),e&&e.setStatus(t,i)},setStatusMessage:function(e){this._elements.fileStatusContainer.innerHTML=e},setPercent:function(e){var t=this._elements.progressBar;e<=0?e="0":e>=100&&(e="100"),t.style.width=e+"%",$common.setText(t,String.format(Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage,e))},get_allowedFileTypes:function(){return this._allowedFileTypes},set_allowedFileTypes:function(e){this._allowedFileTypes=e},get_contextKey:function(){return this._contextKey},set_contextKey:function(e){this._contextKey=e},get_postBackUrl:function(){return this._postBackUrl},set_postBackUrl:function(e){this._postBackUrl=e},get_mode:function(){return this._mode},set_mode:function(e){this._mode=e},get_autoStartUpload:function(){return this._autoStartUpload},set_autoStartUpload:function(e){this._autoStartUpload=e},get_serverPollingSupport:function(){return this._serverPollingSupport},set_serverPollingSupport:function(e){this._serverPollingSupport=e},get_throbber:function(){return this._throbber},set_throbber:function(e){this._throbber=e},get_maximumNumberOfFiles:function(){return this._maximumNumberOfFiles},set_maximumNumberOfFiles:function(e){this._maximumNumberOfFiles=e},get_chunkSize:function(){return this._chunkSize},set_chunkSize:function(e){this._chunkSize=e},get_clearFileListAfterUpload:function(){return this._clearFileListAfterUpload},set_clearFileListAfterUpload:function(e){this._clearFileListAfterUpload=e},get_useAbsoluteHandlerPath:function(){return this._useAbsoluteHandlerPath},set_useAbsoluteHandlerPath:function(e){this._useAbsoluteHandlerPath=e},get_maxFileSize:function(){return this._maxFileSize},set_maxFileSize:function(e){this._maxFileSize=e},get_uploadHandlerPath:function(){return this._uploadHandlerPath},set_uploadHandlerPath:function(e){this._uploadHandlerPath=e},get_enabled:function(){return this.enabled},set_enabled:function(e){this.enabled=e},add_uploadStart:function(e){this.get_events().addHandler("uploadStart",e)},remove_uploadStart:function(e){this.get_events().removeHandler("uploadStart",e)},raiseUploadStart:function(e){Sys.Extended.Deprecated("raiseUploadStart(e)","raise_uploadStart(e)"),this.raise_uploadStart(e)},raise_uploadStart:function(e){var t=this.get_events().getHandler("uploadStart");if(t){var i=new Sys.Extended.UI.AjaxFileUploadStartEventArgs(e.FilesInQueue,e.ServerArguments);t(this,i)}},add_uploadComplete:function(e){this.get_events().addHandler("uploadComplete",e)},remove_uploadComplete:function(e){this.get_events().removeHandler("uploadComplete",e)},raiseUploadComplete:function(e){Sys.Extended.Deprecated("raiseUploadComplete(e)","raise_uploadComplete(e)"),this.raise_uploadComplete(e)},raise_uploadComplete:function(e){var t=this.getCurrentFileItem();if(!t||!e||e.FileId!==t._id)throw"Invalid finalizing upload server response.";this.setFileStatus(t,"uploaded",Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded),this.setStatusMessage("Uploaded "+this._currentQueueIndex+" of "+this._filesInQueue.length+" file(s)"),t._isUploaded=!0,t._isUploading=!1,t.hide();var i=this.get_events().getHandler("uploadComplete");if(i){var n=Array.indexOf(this._filesInQueue,t),l=new Sys.Extended.UI.AjaxFileUploadEventArgs(e.FileId,e.StatusMessage,e.FileName,e.FileSize,e.ContentType,e.PostedUrl,n,this._filesInQueue.length);i(this,l)}},add_uploadCompleteAll:function(e){this.get_events().addHandler("uploadCompleteAll",e)},remove_uploadCompleteAll:function(e){this.get_events().removeHandler("uploadCompleteAll",e)},raiseUploadCompleteAll:function(e){Sys.Extended.Deprecated("raiseUploadCompleteAll(e)","raise_uploadCompleteAll(e)"),this.raise_uploadCompleteAll("raiseUploadCompleteAll(e)","raise_uploadCompleteAll(e)")},raise_uploadCompleteAll:function(e){var t=this.get_events().getHandler("uploadCompleteAll");if(t){var i=new Sys.Extended.UI.AjaxFileUploadCompleteAllEventArgs(e.FilesInQueue,e.FilesUploaded,e.Reason,e.ServerArguments);t(this,i)}},add_uploadError:function(e){this.get_events().addHandler("uploadError",e)},remove_uploadError:function(e){this.get_events().removeHandler("uploadError",e)},raiseUploadError:function(e){Sys.Extended.Deprecated("raiseUploadError(e)","raise_uploadError(e)"),this.raise_uploadError(e)},raise_uploadError:function(e){var t=this.get_events().getHandler("uploadError");t&&t(this,e),this._processor.resetUI(),this._canceled=!1,this._isUploading=!1,this._isUploaded=!0,this.enableControls(!0)},getCurrentFileItem:function(){return this.getFileItem(this._currentFileId)},getNextFile:function(){if(!this._isUploading)return null;for(var e=0;e<this._filesInQueue.length;e++){var t=this._filesInQueue[e];if(!t._isUploaded)return t}return null},getFileItem:function(e){for(var t=0;t<this._filesInQueue.length;t++){var i=this._filesInQueue[t];if(i._id===e)return i}return null}},Sys.Extended.UI.AjaxFileUpload.Control.registerClass("Sys.Extended.UI.AjaxFileUpload.Control",Sys.Extended.UI.ControlBase);