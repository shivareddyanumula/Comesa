        Telerik.Web.UI.RadComboBox.prototype.postback = function(command) {
            if (!this._postBackReference) return;
            var postbackFunction = this._postBackReference.replace("arguments",
        Sys.Serialization.JavaScriptSerializer.serialize(command));
            if (Telerik.Web.UI.RadComboBox.isIEDocumentMode8())
                this.get_element().focus();
            eval(postbackFunction);
        };
    