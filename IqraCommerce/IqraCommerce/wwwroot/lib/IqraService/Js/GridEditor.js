var Controller=new function(){function c(){t.Wait("Please Wait while saving data......");var r={Id:n.model.id,RelationType:n.model.setting.relationtype||"Aplication",Content:JSON.stringify(i.Grid.GetData())};console.log(["data",r]);Global.CallServer("/IqraGridArea/IqraGrid/Add",function(u){t.Free();u.IsError||(n.Success(r.Content),e(),i.Choice.Close(),localStorage.removeItem(n.model.id))},function(){t.Free()},r,"POST")}function l(){var t=i.Grid.GetData();localStorage.setItem(n.model.id,JSON.stringify(t));n.Success(t.Content);i.Choice.Close();e()}function a(){t.Wait("Please Wait while saving data......");Global.CallServer("/IqraGridArea/IqraGrid/Remove?Id="+n.model.id,function(r){t.Free();r.IsError||(n.Success({}),e(),i.Choice.Close(),localStorage.removeItem(n.model.id))},function(){t.Free()},{},"POST")}function v(){localStorage.removeItem(n.model.id);n.Success({});e();i.Choice.Close()}function e(){t&&t.Hide()}function o(t,i){r[t]=typeof r[t]!=typeof none?r[t]:typeof n.model[t]!=typeof none?n.model[t]:IqraConfig.Grid[i]||!1;f[t]=r[t]}function s(n){typeof n.filter!=typeof none?typeof n.filter!=typeof n&&(n.filter=n.filter?this.filter?this.filter:!0:!1):n.filter=this.filter;typeof n.filter==typeof n&&(n.filterObject=n.filter,n.filter=!0)}function h(){var u={};r=n.savedData||{};o("responsive","Responsive");o("printable","Printable");o("selector","selector");o("resizable","resizable");r.columns=r.columns||[];r.columns.each(function(){u[this.field]=this});var f=[],t,e=0,h=r.columns.length,c=n.model.selector?n.model.selector.columns:n.model.columns;c.each(function(n){t=u[this.field]?Global.Copy({},u[this.field],!0):none;t?(t.Index=n+1,t.order=e++,t.selected=this.selected===!1?!1:!0,s.call(this,t),t.sorting=typeof t.sorting!=typeof none?t.sorting:this.sorting===!1?!1:!0,t.title=t.title?t.title:this.title||this.field,t.width=this.width?this.width:"",f.push(t)):(t={field:this.field,selected:this.selected===!1?!1:!0,sorting:this.sorting===!1?!1:!0,title:this.title||this.field,width:this.width?this.width:"",Index:n+1,order:h++},s.call(this,t),f.push(t))});i.Grid.Set(f.orderBy("order"));console.log(["callerOptions",n])}function y(){t=Global.Window.Bind('<div class="formBody"><div class="row formHeader headerFormMenu"><div style="float: left" class="widget-title"><h4 style="margin:5px;" class="auto_bind" data-binding="Title">Grid Editor<\/h4><\/div><span class="pull-right button_container"><a class="button btn_cancel"><span class="glyphicon glyphicon-remove"><\/span><\/a><\/span><\/div><div class="middleForm"><div class="attr_container"><label class="lbl_selector"><input type="checkbox" data-binding="responsive" /> Is Responsive <\/label><label class="lbl_selector" style="margin-left: 15px;"><input type="checkbox" data-binding="printable" /> Is Printable <\/label><label class="lbl_selector" style="margin-left: 15px;"><input type="checkbox" data-binding="selector" /> Is Column Selector <\/label><label class="lbl_selector" style="margin-left: 15px;"><input type="checkbox" data-binding="resizable" /> Is Column Resizable <\/label><\/div><div class="grid_container"><\/div><div class="row"><div class="text-center formFooter FooterFormMenu"><button class="btn btn_save btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-save"><\/span> Save <\/button><button class="btn btn_remove btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-trash"><\/span> Remove <\/button><button class="btn btn_cancel btn-white btn-default btn-round" type="button"> <span class="glyphicon glyphicon-remove"><\/span> Cancel <\/button><\/div><\/div><\/div><\/div>');Global.Form.Bind(f,t.View);t.View.find(".btn_cancel").click(e);Global.Click(t.View.find(".btn_save"),i.Choice.Open,!0);Global.Click(t.View.find(".btn_remove"),i.Choice.Open);t.Show();h()}var t,f={},n,r,i={},u;this.Show=function(i){n=i;t?(t.Show(),h()):y()},function(){function o(n,t){var o=t.prev(),i=n.Index-1,f=u.dataSource[i],e=u.dataSource[i-1];u.dataSource[i]=e;u.dataSource[i-1]=f;f.Index--;e.Index++;o.before(t);f.Index===1&&(t.find(".order").empty(),r(e,o))}function r(n,t){if(n.Index>1){var i=$('<a title="Go Up" style="font-size: 1.5em;"><span class="glyphicon glyphicon-chevron-up"><\/span><\/a>');t.find(".order").empty().append(i);Global.Click(i,o,n,!1,t)}else t.find(".order").empty()}function s(n){var i,t;n.find(".slted").empty().append('<label><input type="checkbox" data-binding="selected" /> <\/label>');n.find(".filter").empty().append('<label><input type="checkbox" data-binding="filter" /> <\/label>');n.find(".sorting").empty().append('<label><input type="checkbox" data-binding="sorting" /> <\/label>');n.find(".title").empty().append('<input data-binding="title" class="form-control" data-type="string" style="max-width: calc(100% - 14px);" type="text">');n.find(".width").empty().append('<input data-binding="width" class="form-control" data-type="string" style="max-width: calc(100% - 14px);" type="text">');r(this,n);i=this.FormModel;this.FormModel=this.FormModel||{};Global.Form.Bind(this.FormModel,n);for(t in this.FormModel)typeof this[t]!="undefined"&&(this.FormModel[t]=this[t]);if(i)for(t in i)this.FormModel[t]=i[t]}function h(n){Global.Grid.Bind({elm:t.View.find(".grid_container"),columns:[{field:"Index",title:"SL#",sorting:!1},{field:"selected",title:"Is Selected",sorting:!1,autoBind:!1,className:"slted"},{field:"filter",sorting:!1,title:"Is Filterable",autoBind:!1,className:"filter"},{field:"sorting",sorting:!1,title:"Is Sorting",autoBind:!1,className:"sorting"},{field:"title",sorting:!1,title:"Title",autoBind:!1,className:"title",width:"20%"},{field:"width",sorting:!1,title:"Width",autoBind:!1,className:"width",width:"20%"},{field:"order",sorting:!1,title:"Actions",autoBind:!1,className:"order action"}],dataSource:n,page:{PageNumber:1,PageSize:1e3},rowBound:s,action:{title:"Actions",items:[{click:i.Filter.Open,html:'<span class="icon_container btn_add_files" title="Add Files"><span class="glyphicon glyphicon-open"><\/span><\/span>'}],className:"action"},pagger:!1,pagging:!1,Printable:!1,responsive:!1,selector:!1,onComplete:function(n){u=n}})}var e=0;this.Set=function(n){e=n.length;u?(u.dataSource=n,u.Reload()):h(n)};this.GetData=function(){var t={Version:parseFloat((n.model.version||IqraConfig.Version||0)+""),responsive:f.responsive,printable:f.printable,selector:f.selector,resizable:f.resizable,columns:[]};return u.dataSource.each(function(n){var i={order:n,field:this.field,selected:this.FormModel.selected,filter:this.FormModel.filter?this.filterObject?this.filterObject:!0:!1,sorting:this.FormModel.sorting,title:this.FormModel.title,width:this.FormModel.width.trim().toLowerCase()};i.width&&i.width!="fit"&&i.width[i.width.length-1]!="%"&&(i.width=parseFloat(i.width));t.columns.push(i)}),t}}.call(i.Grid={}),function(){function o(n,t){return'<section class="col-sm-6 col col-md-6"><div><label for="'+n+'">'+t+'<\/label><\/div><div class="input-group"><input data-type="string" data-binding="'+n+'" class="form-control" type="text"><\/div><\/section>'}function e(n,t,i,r){return'<div class="row">'+o(n,t)+o(i,r)+"<\/div>"}function a(n){u.filterObject=u.filterObject||{};r.Type={elm:$(n.type),dataSource:[{text:"Multi-Select",value:""},{text:"Auto-Complete",value:"1"},{text:"Multi-Select  and Search By Text",value:"2"}],selectedValue:u.filterObject.type};r.Display={elm:$(n.displaytype),dataSource:[{text:"Search By Text",value:""},{text:"Multi-Select",value:"1"}],selectedValue:u.filterObject.displaytype};Global.DropDown.Bind(r.Type);Global.DropDown.Bind(r.Display)}function v(t){i=Global.Window.Bind('<div class="formBody"><div class="row formHeader headerFormMenu"><div style="float: left" class="widget-title"><h4 style="margin:5px;">Grid Filter Editor<\/h4><\/div><span class="pull-right button_container"><a class="button btn_cancel"><span class="glyphicon glyphicon-remove"><\/span><\/a><\/span><\/div><div class="middleForm"><div class="attr_container">'+e("type","Search Type","displaytype","First Display Type")+e("field","Search By","url","Data Url")+e("valuefield","Data Value Field","textfield","Data Title Field")+'<\/div><div class="empty_style button_container row"><a class="btn btn-white btn-default btn-round pull-right btn_add_new_row" style="margin: 0px;"><span class="glyphicon glyphicon-plus"><\/span>New<\/a><\/div><div class="grid_container"><\/div><div class="row"><div class="text-center formFooter FooterFormMenu"><button class="btn btn_save btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-save"><\/span> Save <\/button><button class="btn btn_cancel btn-white btn-default btn-round" type="button"> <span class="glyphicon glyphicon-remove"><\/span> Cancel <\/button><\/div><\/div><\/div><\/div>');a(Global.Form.Bind(n,i.View));i.View.find(".btn_cancel").click(s);Global.Click(i.View.find(".btn_save"),y);Global.Click(i.View.find(".btn_add_new_row"),f.Grid.AddNew);h(t)}function y(){var t=f.Grid.GetData();if(!t.IsValid){alert(t.Msg);return}t={datasource:t.dataSource.length?t.dataSource:none,type:n.type?parseInt(n.type):none,displaytype:n.displaytype?parseInt(n.displaytype):none,field:n.field?n.field:none,url:n.url?n.url:none,valuefield:n.valuefield?n.valuefield:none,textfield:n.textfield?n.textfield:none};console.log(["model",t,filterModel]);u.filterObject=t;s()}function s(){i&&i.Hide()}function p(t){console.log(["model",t,r.Type&&r.Type.val]);for(var i in n)n[i]=t[i]?t[i]:"";r.Type&&r.Type.val&&(r.Type.val(t.type),r.Display.val(t.displaytype))}function h(n){i.Show();p(u.filterObject);f.Grid.Set(n)}function w(n){n.filterObject=n.filterObject||{};n.filterObject.datasource=n.filterObject.datasource||[];var t=[],i=n.filterObject.valuefield||"Id",r=n.filterObject.textfield||"Name";return n.filterObject.datasource.each(function(){t.push({Title:this[r],Value:this[i]})}),t}var i,n={},t,f={},u,c,l,r={};this.Open=function(n){u=n;var t=w(n);i?h(t):v(t)},function(){function f(i,r){var o=r.prev(),u=i.Index-1,f=t.dataSource[u],e=t.dataSource[u-1];t.dataSource[u]=e;t.dataSource[u-1]=f;f.Index--;e.Index++;o.before(r);f.Index===1&&(r.find(".order").empty(),n(e,o))}function n(n,t){if(n.Index>1){var i=$('<a title="Go Up" style="font-size: 1.5em;"><span class="glyphicon glyphicon-chevron-up"><\/span><\/a>');t.find(".order").empty().append(i);Global.Click(i,f,n,!1,t)}else t.find(".order").empty()}function e(t){var r,i;t.find(".title").empty().append('<input data-binding="Title" required="" class="form-control" data-type="string" style="max-width: calc(100% - 14px);" type="text">');t.find(".value").empty().append('<input data-binding="Value" required="" class="form-control" data-type="string" style="max-width: calc(100% - 14px);" type="text">');n(this,t);r=this.FormModel;this.Id=u++;this.FormModel={};Global.Form.Bind(this.FormModel,t);for(i in this.FormModel)typeof this[i]!="undefined"&&(this.FormModel[i]=this[i]);if(r)for(i in r)this.FormModel[i]=r[i]}function o(){t.Body.view.find("tr").each(function(n){var t=$(this).data("model");t.Index=n+1})}function s(n){var r=$(this).closest("tr"),i=[];t.dataSource.each(function(){this.Id!=n.Id&&i.push(this)});t.dataSource=i;r.remove();o()}function h(n){Global.Grid.Bind({elm:i.View.find(".grid_container"),columns:[{field:"Index",title:"SL#",sorting:!1},{field:"Title",title:"Title",autoBind:!1,className:"title"},{field:"Value",autoBind:!1,className:"value"},{field:"order",sorting:!1,title:"Actions",autoBind:!1,className:"order action"}],dataSource:n,page:{PageNumber:1,PageSize:1e3},rowBound:e,action:{title:"Actions",items:[{click:s,html:'<span class="icon_container btn_add_files" title="Add Files"><span class="glyphicon glyphicon-trash"><\/span><\/span>'}],className:"action"},pagger:!1,pagging:!1,Printable:!1,responsive:!1,selector:!1,onComplete:function(n){t=n}})}var r=0,u=0;this.Set=function(n){r=n.length;t?(t.dataSource=n,t.Reload()):h(n)};this.GetData=function(){var n={Msg:"",IsValid:!0,dataSource:[]},i;return t.dataSource.each(function(){this.FormModel.IsValid?(i={},i[c]=this.FormModel.Value,i[l]=this.FormModel.Title,n.dataSource.push(i)):this.FormModel.Title?(n.IsValid=!1,n.Msg="Title Field is Missing."):(n.IsValid=!1,n.Msg="Value Field is Missing.")}),n};this.AddNew=function(){t.AddTottom({Title:"",Value:"",Index:t.dataSource.length+1})}}.call(f.Grid={})}.call(i.Filter={}),function(){function t(){n&&n.Hide()}function i(t){t?(n.View.find(".btn_save_server").show(),n.View.find(".btn_remove_server").hide(),n.View.find(".btn_save_brouser").show(),n.View.find(".btn_remove_browser").hide()):(n.View.find(".btn_save_server").hide(),n.View.find(".btn_remove_server").show(),n.View.find(".btn_save_brouser").hide(),n.View.find(".btn_remove_browser").show());n.Show()}function r(r){n=Global.Window.Bind('<div class="formBody"><div class="middleForm"><div class="row"><div class="text-center formFooter FooterFormMenu"><button class="btn btn_save_server btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-save"><\/span> Save For All <\/button><button class="btn btn_save_brouser btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-save"><\/span> Save Only For This Browser <\/button><button class="btn btn_remove_server btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-trash"><\/span> Remove From All <\/button><button class="btn btn_remove_browser btn-white btn-default btn-round" type="button" style="margin-right: 10px;"><span class="glyphicon glyphicon-trash"><\/span> Remove Only From This Browser <\/button><button class="btn btn_cancel btn-white btn-default btn-round" type="button"> <span class="glyphicon glyphicon-remove"><\/span> Cancel <\/button><\/div><\/div><\/div><\/div>');n.View.find(".btn_cancel").click(t);Global.Click(n.View.find(".btn_save_server"),c);Global.Click(n.View.find(".btn_remove_server"),a);Global.Click(n.View.find(".btn_save_brouser"),l);Global.Click(n.View.find(".btn_remove_browser"),v);i(r)}var n;this.Open=function(t){n?i(t):r(t)};this.Close=function(){t()}}.call(i.Choice={})}