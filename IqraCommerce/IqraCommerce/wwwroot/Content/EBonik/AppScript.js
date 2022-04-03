﻿var BodyParent = {};
(function () {
    var view = BodyParent.View = {}, items, currentIndex = 0;
    function resetMenu(index) {
        if (items[currentIndex]) {
            items[currentIndex].elm.removeClass('active');
        }
        currentIndex = index;
        items[currentIndex] && items[currentIndex].elm.addClass('active');
    };
    function setSummary(container, title, rtnFunc, parentContainer) {

        container.append(container = $('<div class="columns-container">'));
        container.append(container = $('<div id="columns" class="container">'));
        container.append(container = $('<div class="breadcrumb clearfix">'));
        container.append(Global.Click($('<a class="home" title="Return to Home">Home</a>'), rtnFunc, parentContainer));
        container.append('<span class="navigation-pipe"> </span>');
        container.append('<a href="#">' + title + '</a>');
    };
    function getSection(container, formModel, field, title, cls, inputs) {
        cls = cls || 'col-md-3 col-sm-6';
        inputs = inputs || {};
        container.append(container = $('<div class="' + cls + '">'));
        container.append(inputs[field] = Global.AutoBind2(formModel, $('<input class="form-control" placeholder="' + title + '" type="text">'), field));
        return container;
    };
    function getSectionWithLabel(container, formModel, field, title, cls) {
        cls = cls || 'col-md-3 col-sm-6';
        container.append(container = $('<div class="' + cls + '">'));
        container.append('<div><label>' + title + '</label></div>');
        container.append(container = $('<div>'));
        container.append(Global.AutoBind(formModel, $('<label class="form-control">0.00</label>'), field, 2));
        return container;
    };
    function getSectionWithTitle(container, formModel, field, title, cls, inputs, isDisabled) {
        cls = cls || 'col-md-3 col-sm-6';
        inputs = inputs || {};
        container.append(container = $('<div class="' + cls + '">'));
        container.append('<div><label>' + title + '</label></div>');
        container.append(container = $('<div>'));
        container.append(inputs[field] = Global.AutoBind2(formModel, $('<input class="form-control"' + (isDisabled ? ' disabled=""' : '') + ' placeholder="' + title + '" type="text">'), field));
        return container;
    };
    function getTextAreaSectionWithTitle(container, formModel, field, title, cls, inputs, isDisabled) {
        cls = cls || 'col-md-3 col-sm-6';
        inputs = inputs || {};
        container.append(container = $('<div class="' + cls + '">'));
        container.append('<div><label>' + title + '</label></div>');
        container.append(container = $('<div>'));
        container.append(inputs[field] = Global.AutoBind2(formModel, $('<textarea class="form-control" style="height: 25%;"' + (isDisabled ? ' disabled=""' : '') + ' placeholder="' + title + '" type="text">'), field));
        return container;
    };
    function setFooterNotice(container) {

        //container.append('<div class="notice"><p class="SearchFont SearchPrice">*** Please pay first for outside Dhaka delivery</p>' +
        //    '<p class="SearchFont SearchPrice">*** Please pay the delivery charge first for inside Dhaka delivery (Cash on Delivery)</p>' +
        //    '<p class="SearchFont SearchPrice">*** Delivery within 24 hours if ordered between 10am to 7pm </p>' +
        //    '<p class="SearchFont SearchPrice">*** All deliveries are closed on Fridays </p>' +
        //    '</div >');
        container.append('<div class="notice" style= "margin-top: 4%; border-bottom: 1px dashed black; border-top: 1px dashed black;"><p class="SearchFont SearchPrice">*** Delivery within 24 to 48 hours if ordered between 10am to 7pm </p>' +
            '<p class="SearchFont SearchPrice">*** All deliveries are closed on Fridays </p>' +
            '</div >');
    };

    (function (parent) {
        var view = { Parent: parent };
        (function (parent) {
            var view = {};

            function onSubCategoryClick(Id) {
                BodyParent.View.ProductSubCategoryDetails.Render(BodyParent.Container, Id);
            }

            function setSection(list, from, increment, container) {
                var ul;
                container.append($('<div class="mega-group col-sm-4">').append(ul = $('<ul class="group-link-default">')));
                increment += from;

                for (var i = from; i < list.length && i < increment; i++) {
                    //ul.append('<li><a href="/Home/ProductCategory">' + list[i].Name + '</a></li>');
                    //console.log("[list[i].Id]", list[i]);
                    li = Global.Click($('<li><a href="/ProductSubCategoryDetails/Index?Id=' + list[i].Id + '">'
                        + list[i].Name + '</a></li>'), onSubCategoryClick, list[i].Id);
                    ul.append(li);
                }
            };
            function setSubCategory(list, li) {
                var container;
                li.append($('<div class="vertical-dropdown-menu"><a href="#">').append(container = $('</a><div class="vertical-groups col-sm-12">')));
                var increment = 4;
                if (list.length > 12) {
                    increment = Math.ceil(list.length / 3);
                }
                for (var i = 0; i < list.length; i += increment) {
                    setSection(list, i, increment, container);
                }
            };

            function setCategory(model, container) {
                //var cls = model.SubCategory ? 'parent' : '', li = $('<li><a class="' + cls + '" href="/Home/ProductCategory"><img class="icon-menu" alt="Funky roots" src="/Content/assets/iqraimages/CategoryIcon/medicine.png">' + model.Name + '</a></li>')
                var cls = model.SubCategory ? 'parent' : '', li = Global.Click($('<li><a class="' + cls + '" href="/ProductCategoryDetails/Index?Id=' + model.Id + '"><img class="icon-menu" alt="Lazz" src="/Content/assets/iqraimages/CategoryIcon/medicine.png">' + model.Name + '</a></li>'), function () {
                   BodyParent.View.ProductCategoryDetails.Render(BodyParent.Container, model.Id);
                });
                container.append(li);
                model.SubCategory && setSubCategory(model.SubCategory, li)
            };
            function createView(list, container) {
                list.each(function () {
                    setCategory(this, container);
                });
            };
            function setData(list, container) {
                var dic = {};
                list[1].each(function () {
                    if (!dic[this.ProductCategoryId]) {
                        dic[this.ProductCategoryId] = [];
                    }
                    dic[this.ProductCategoryId].push(this);
                });
                list[0].each(function () {
                    this.SubCategory = dic[this.Id];
                });
                createView(list[0], container);
            };
            function loadCategory(container) {
                Global.CallServer('/ProductArea/ProductCategory/GetMenu', function (response) {
                    if (!response.IsError) {
                        setData(response.Data, container);
                    } else {

                    }
                }, function (response) {
                    response.Id = -8;
                }, {}, 'GET');
            };
            this.Render = function (container) {
                view.Container = container.empty();
                container.append(container = $('<div class="box-vertical-megamenus" style="left: 0px;">'));
                container.append('<h4 class="title"><span class="title-menu">Categories</span><span class="btn-open-mobile pull-right home-page"><i class="fa fa-bars"></i></span></h4>');
                container.append(container = $('<div class="vertical-menu-content is-home">'));
                container.append(container = $('<ul id="category_left_menu" class="vertical-menu-list">'));
                if (window.appData && window.appData.Data && window.appData.Data.Data && window.appData.Data.Data.length) {
                    setData([AppBase.GetData(0), AppBase.GetData(1)], container);
                } else {
                    loadCategory(container);
                }
                return view.Container;
            };
            this.Remove = function () {
                view.Container.empty();
            };
        }).call(view.NavTopCategory = BodyParent.NavTopCategory = {}, view);
        (function (parent) {
            var view = {};
            function createNavHeader(container) {
                container.append(container = $('<div class="navbar-header">'));
                //container.append($('<i class="fa fa-bars" style="position: absolute;left: 28px;width: 90 %;line-height: 50px;"></i>'));
                container.append($('<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar" style="position: absolute;left:15px; text-align: left; width: 90%;"><i class="fa fa-bars" style="font-size: 19px"></i><span class= "Mobile_Menu"> MENU </span></button>'));
                //container.append($('<a class="navbar-brand" href="#">MENU</a>'));
            };
            function getItems() {
                if (items) {
                    return items;
                } else {
                    return items = [
                        { title: 'Home', click: parent.Parent.Home.Render, url: '/' },
                        { title: 'Order Us', click: parent.Parent.UrgentOrder.Render, url: '/Home/OrderUs' },
                        { title: 'Branch Location', click: parent.Parent.FindStore.Render, url: '/Home/FindStore' },
                        { title: 'Review', click: parent.Parent.Comments.Render, url: '/Home/Comments' },
                        { title: 'Career', click: parent.Parent.Career.Render, url: '/Home/Career' },
                        { title: 'Gallery', click: parent.Parent.Gallery.Render, url: '/Home/Gallery' },
                        { title: 'About Us', click: parent.Parent.AboutUs.Render, url: '/Home/AboutUs' },
                        { title: 'Contact Us', click: parent.Parent.ContactUs.Render, url: '/Home/ContactUs' },
                        //{ title: 'Request Order', click: parent.Parent.RequestOrder.Render, url: '/Home/RequestOrder' },
                        //{ title: 'How to Order', click: parent.Parent.HowToOrder.Render, url: '/Home/HowtoOrder' },
                    ];
                }
            };
            function setItems(container, rightContainer) {
                getItems().each(function () {
                    var itm = this;
                    container.append(itm.elm = Global.Click($('<li><span></span><a href="' + (itm.url || '#') + '">' + itm.title + '</a></li>'), function () {
                        itm.click(rightContainer);
                    }));
                });
            };
            this.Render = function (container, bodyContainer) {
                var elm;
                view.Container = container.empty();
                container.append(container = $('<nav class="navbar navbar-default">'));
                container.append(container = $('<div class="container-fluid" style="padding: 0px;">'));
                createNavHeader(container);
                container.append(container = BodyParent.NavbarContainer = $('<div id="navbar" class="navbar-collapse collapse">'));
                container.append(container = $('<ul class="nav navbar-nav">'));

                setItems(container, bodyContainer);
                return view.Container;
            };
        }).call(view.NavTopMainMenu = {}, view);
        this.Render = function (container, bodyContainer) {
            var elm;
            view.Container = container.empty();
            container.append(container = $('<div class="container">'));
            container.append(elm = $('<div class="row">'));
            //id="box-vertical-megamenus" class="col-sm-3"
            elm.append(view.NavTopCategory.Render($('<div id="box-vertical-megamenus" class="nav_top_category_container col-sm-3">')));
            elm.append(view.NavTopMainMenu.Render($('<div id="main-menu" class="col-sm-9 main-menu">'), bodyContainer));

            return view.Container;
        };
        this.Reset = function () {
            view.Container.removeClass('home');
        };
        this.Set = function () {
            view.Container.addClass('home');
        };
    }).call(view.NavTopMenu = BodyParent.NavTopMenu = {}, view);

    (function (parent) {
        var view = { Parent: parent };
        (function (parent) {
            var view = { Parent: parent }, isReady;
            function setImages(container) {
                //BodyParent.SliderImg = ['/Content/Img/Slider/IMG_5123.JPG', '/Content/Img/Slider/IMG_5122.JPG', '/Content/Img/Slider/IMG_5121.JPG', '/Content/Img/Slider/IMG_5120.JPG'];
                AppService && AppService.Slider && (AppService.Slider.Img || []).each(function () {
                    container.append('<li><img alt="' + this.title + '" src="' + this.img + '" title="' + this.title + '" /></li>');
                });
            };
            function bind(container) {
                setTimeout(function () {
                    var slider = container.bxSlider(
                        {
                            nextText: '<i class="fa fa-angle-right"></i>',
                            prevText: '<i class="fa fa-angle-left"></i>',
                            auto: true,
                        }
                    );
                }, 50);
            };
            this.Render = function (container) {
                view.Container = container.empty();
                container.append(container = $('<div class="container">'));
                container.append(container = $('<div class="row">'));
                container.append($('<div class="col-sm-3 slider-left"></div>'));
                container.append(container = $('<div class="col-sm-9 header-top-right">'));
                container.append(container = $('<div class="homeslider">'));
                container.append(container = $('<ul id="contenhomeslider">'));
                setImages(container);
                bind(container);
                return view.Container
            };
        }).call(view.Slider = {}, view);

        (function (parent) {
            var view = { Parent: parent }, tabs, tabIndex = 0, formModel = {};
            function resetTab(index) {
                if (tabs[tabIndex]) {
                    tabs[tabIndex].elm.removeClass('active');
                }
                tabIndex = index;
                tabs[tabIndex].elm.addClass('active');
            };
            (function (parent) {
                var view = { Parent: parent };
                function getItems() {
                    if (tabs) {
                        return tabs;
                    } else {
                        var datasource;
                        if (window.appData && window.appData.Data && window.appData.Data.Data && window.appData.Data.Data.length) {
                            datasource = AppBase.GetData(4);
                            console.log(['datasource', datasource]);
                        }
                        return tabs = [
                            {
                                Name: 'Featured Product', title: 'Featured Product', Url: '/ProductArea/Product/FeaturedProduct',
                                filter: function () {
                                    return [];
                                },
                                click: view.Parent.TabContent.Render,
                                datasource: datasource
                            },
                            //{
                            //    Name: 'DealsOfTheWeek', IsActive: true,
                            //    title: 'Deals Of The Week',
                            //    Url: '/ProductArea/Product/DealsOfTheWeek',
                            //    filter: function () {
                            //        return [];
                            //    },
                            //    click: view.Parent.TabContent.Render
                            //},
                        ];
                    }
                };
                function setItems(container, rightContainer) {
                    getItems().each(function (i) {
                        var itm = this;
                        this.index = i;
                        container.append(itm.elm = Global.Click($('<li><a href="' + (itm.url || '#') + '">' + itm.title + '</a></li>'), function () {
                            itm.click(rightContainer, itm, itm.data);
                        }));
                    });
                };
                this.Render = function (container, contentContainer) {
                    view.Container = container.empty();
                    container.append(container = $('<div class="container">'));
                    container.append(container = $('<div class="collapse navbar-collapse">'));
                    container.append(container = $('<ul id="sale_tab_button" class="nav navbar-nav">'));
                    setItems(container, contentContainer);
                    return view.Container
                };
            }).call(view.NavbarMenu = {}, view);
            (function (parent) {
                var view = { Parent: parent };
                function addToCart(evnt, container, data) {
                    var elm = container.closest('.main_dispaly');
                    AppBase.CartBox.Add(data, elm, evnt);
                };
                function setMyWishlist(container, data) {
                    //console.log(['setMyWishlist', container, data]);
                };
                function addToCompare(container, data) {
                    //console.log(['addToCompare', container, data]);
                };
                function quickview(container, data) {
                    //console.log(['quickview', container, data]);
                };
                function setAddToCart(container, data) {
                    //if (data.TotalStock > 0) {
                        container.append(AppBase.Click($('<div><div style="text-align: center;"><div class="btn_cart">' +
                            '<a class="btn_add_to_cart" title="Add to Cart" href="#"><img src="/Content/assets/images/icon-cart-option2.png" alt="lp" width="25" height="25"> Add to Cart</a>' +
                            '</div></div></div>'), addToCart, container, data));
                    //} else {
                    //    container.append('<div><div style="text-align: center;"><div class="btn_cart">' +
                    //        '<a class="btn_add_to_cart" title="Out of Stock" style="background-color: #e33030;cursor: default;color: #fff;">Out of Stock</a>' +
                    //        '</div></div></div>');
                    //}
                };
               
                function setDiscountPercent(li, data) {
                    if (data.Discount > 0) {
                        li.append(li = $('<div class="group-price"><span class="product-new">' + data.Discount + '% </span></div>'));
                    }
                }
                function setLeftBlock(li, data) {
                    var quickView, leftBlock;
                    li.append(leftBlock = $('<div class="left-block">'));
                    leftBlock.append(Global.Click($('<a href="/ProductArea/Product/Details?Id=' + data.Id + '">' +
                        '<img class ="img-responsive" alt="product" src= "' + AppBase.GetImagePath(data) + '" style="max-height:205px;" />' +
                        '</a>'), ProductDetails.Render, data));
                    //setAddToCart(leftBlock, data);
                };
                function setRightBlock(li, data) {
                    //console.log([data], data);
                    var oldPrice = '', price = data.UnitSalePrice;
                    //console.log([price], price);
                    if (data.Discount > 0) {
                        price = data.UnitSalePrice - data.UnitSalePrice.mlt(data.Discount).div(100);
                        oldPrice = '<del class="cross_price">৳ ' + Math.round(data.UnitSalePrice) + '</del>';
                    }
                    //console.log([data.Discount], data.Discount);
                    li.append(li = $('<div class="right-block">')
                        .append($('<h5 class ="product-name" title= "' + data.Name + ' ' + (data.Strength || '') + ' ' + (data.Category || '') + '" >')
                            .append(Global.Click($('<a href= "/ProductArea/Product/Details?Id=' + data.Id + '" > ' + data.Name + ' ' + (data.Strength || '') + ' ' + (data.Category || '') + ' </a>'), ProductDetails.Render, data)))
                    );
                    li.append('<div class="content_price"> <span class ="price product-price">৳ ' + price.toFloat(1) + ' </span><span class ="price product-price">' + oldPrice + '</span> </div>');
                };
                function setContent(ul, data) {
                    var li;
                    ul.append(li = $('<li class="col-sm-2 col-md-2 col-xs-6 main_dispaly_container">'));
                    li.append(li = $('<div class="main_dispaly">'));
                    
                    setLeftBlock(li, data);
                    setDiscountPercent(li, data);
                    setRightBlock(li, data);
                    setAddToCart(li, data);
                };

                function setRightPanel(container, data) {
                    var ul, item;
                    container.append($('<div class="">').append(ul = $('<ul class="product-list row">')));
                    data.each(function () {
                        item = {
                            "Id": this.Id || this[0],
                            "Name": this.Name || this[1],
                            "GenericName": this.GenericName ||  this[2],
                            "Strength": this.Strength ||  this[3],
                            "UnitSalePrice": this.UnitSalePrice ||  this[4],
                            "Discount": this.Discount ||  this[5],
                            "ImagePath": this.ImagePath ||  this[6],
                            "ImageType": this.ImageType || this[7],
                            "Category": this.Category || this[8],
                            "Suplier": this.Suplier || this[9],
                            "TotalStock": this.TotalStock || this[10],
                        };
                        setContent(ul, item);
                    });
                };
                function load(container, tab) {
                    Global.CallServer(tab.Url, function (response) {
                        if (!response.IsError) {
                            setRightPanel(container, response.Data);
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, {}, 'GET');
                };
                this.Render = function (container, tab, data) {
                    container.empty();
                    resetTab(tab.index);
                    container.append(container = $('<div class="product-featured-tab-content">'));
                    container.append(container = $('<div id="sale_tab_container" class="tab-container">'));
                    container.append(container = $('<div class="tab-panel active">'));
                    if (data && data.each) {
                        setRightPanel(container, data);
                    } else {
                        if (tab.datasource && tab.datasource.length) {
                            setRightPanel(container, tab.datasource);
                        } else {
                            load(container, tab);
                        }
                    }

                };
            }).call(view.TabContent = {}, view);
            this.Render = function (container) {
                var menuContainer, contentContainer, subcategoryContainer;
                view.Container = container.empty();
                container.append(container = $('<div class="container">'));
                container.append(container = $('<div class="category-featured electronic">'));
                container.append(menuContainer = $('<nav class="navbar nav-menu show-brand">'));
                container.append(container = $('<div class="product-featured clearfix">'));
                container.append(container = $('<div class="row">'));
                container.append(contentContainer = $('<div class="col-sm-12 col-right-tab">'));
                view.NavbarMenu.Render(menuContainer, contentContainer);
                tabs && tabs[0] && tabs[0].elm && tabs[0].elm.click();
                return view.Container
            };
        }).call(view.ContentShopPage = {}, view);

        (function (parent) {
            var view = { Parent: parent }, tabs, tabIndex = 0, formModel = {};
            function resetTab(index) {
                if (tabs[tabIndex]) {
                    tabs[tabIndex].elm.removeClass('active');
                }
                tabIndex = index;
                tabs[tabIndex].elm.addClass('active');
            };
            (function (parent) {
                var view = { Parent: parent };
                function onSubCategoryClick(Id) {
                    BodyParent.View.ProductSubCategoryDetails.Render(BodyParent.Container, Id);
                }
                function createView(list, container) {
                    list.each(function () {
                        li = Global.Click($('<li><a href="/ProductSubCategoryDetails/Index?Id=' + this.Id + '">'
                            + this.Name + '</a></li>'), onSubCategoryClick, this.Id);
                        container.append(li);
                    });
                };
                function setData(list, container) {
                    createView(list[1], container);
                    formModel.SubCategory = list[0][0].Name;
                };
                function load(container) {
                    Global.CallServer('/ProductArea/ProductSubCategory/GetMenu', function (response) {
                        if (!response.IsError) {
                            setData(response.Data, container);
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, {}, 'GET');
                };

                this.Render = function (container, contentContainer) {
                    view.Container = container.empty();
                    container.append(container = $('<ul id="_shop_sub_category_list" class="sub-category-list">'));
                    if (window.appData && window.appData.Data && window.appData.Data.Data && window.appData.Data.Data.length) {
                        setData([[AppBase.GetData(0)[0]],AppBase.GetData(2)], container);
                    } else {
                        load(container);
                    }


                    return view.Container
                };
            }).call(view.SubCategory = {}, view);
            (function (parent) {
                var view = { Parent: parent };
                function getItems() {
                    if (tabs) {
                        return tabs;
                    } else {
                        var datasource;
                        if (window.appData && window.appData.Data && window.appData.Data.Data && window.appData.Data.Data.length) {
                            datasource = AppBase.GetData(3);
                        }
                        return tabs = [
                            {
                                Name: 'Specials',
                                title: 'Specials',
                                Url: '/ProductArea/Product/Specials',
                                filter: function () {
                                    return [];
                                },
                                click: view.Parent.TabContent.Render,
                                datasource: datasource
                            },
                            {
                                Name: 'DealsOfTheWeek', IsActive: true,
                                title: 'Deals Of The Week',
                                Url: '/ProductArea/Product/DealsOfTheWeek',
                                filter: function () {
                                    return [];
                                },
                                click: view.Parent.TabContent.Render
                            },
                            //{
                            //    Name: 'NewArrival', title: 'New Arrival', Url: '/ProductArea/Product/NewArrival',
                            //    filter: function () {
                            //        return [];
                            //    },
                            //    click: view.Parent.TabContent.Render
                            //},
                            //{
                            //    Name: 'OnSales', title: 'On Sales', Url: '/ProductArea/Product/OnSale',
                            //    filter: function () {
                            //        return [];
                            //    },
                            //    click: view.Parent.TabContent.Render
                            //}
                        ];
                    }
                };
                function setItems(container, rightContainer) {
                    getItems().each(function (i) {
                        var itm = this;
                        this.index = i;
                        container.append(itm.elm = Global.Click($('<li><a href="' + (itm.url || '#') + '">' + itm.title + '</a></li>'), function () {
                            itm.click(rightContainer, itm, itm.data);
                        }));
                    });
                };
                this.Render = function (container, contentContainer) {
                    view.Container = container.empty();
                    container.append(container = $('<div class="container">'));
                    container.append($('<div id="selected_category" class="navbar-brand">').append(Global.AutoBind(formModel, $('<a></a>'), 'SubCategory')));
                    //container.append('<span class="toggle-menu"></span>');
                    container.append(container = $('<div class="collapse navbar-collapse">'));
                    container.append(container = $('<ul id="sale_tab_button" class="nav navbar-nav">'));
                    setItems(container, contentContainer);
                    return view.Container
                };
            }).call(view.NavbarMenu = {}, view);
            (function (parent) {
                var view = { Parent: parent };
                function addToCart(evnt, container, data) {
                    var elm = container.closest('.main_dispaly');
                    AppBase.CartBox.Add(data, elm, evnt);
                    //AppBase.CartBox
                };
                function setMyWishlist(container, data) {
                    //console.log(['setMyWishlist', container, data]);
                };
                function addToCompare(container, data) {
                    //console.log(['addToCompare', container, data]);
                };
                function quickview(container, data) {
                    //console.log(['quickview', container, data]);
                };
                function setAddToCart(container, data) {
                    //if (data.TotalStock > 0) {
                        container.append(AppBase.Click($('<div><div style="text-align: center;"><div class="btn_cart">' +
                            '<a class="btn_add_to_cart" title="Add to Cart" href="#"><img src="/Content/assets/images/icon-cart-option2.png" alt="lp" width="25" height="25"> Add to Cart</a>' +
                            '</div></div></div>'), addToCart, container, data));
                    //}
                    //else
                    //{
                    //    container.append('<div><div style="text-align: center;"><div class="btn_cart">' +
                    //        '<a class="btn_add_to_cart" title="Out of Stock" style="background-color: #e33030;cursor: default;color: #fff;">Out of Stock</a>' +
                    //        '</div></div></div>');
                    //}
                    
                };
                //function setQuickView(container, data) {
                //    container.append(Global.Click($('<a title="Add to my wishlist" class="heart" href="#"></a>'), setMyWishlist, container, false, data));
                //    container.append(Global.Click($('<a title="Add to compare" class="compare" href="#"></a>'), addToCompare, container, false, data));
                //    container.append(Global.Click($('<a title="Quick view" class="search" href="#"></a>'), quickview, container, false, data));
                //};
                function setRightBlock(li, data) {

                    //console.log([data], data);
                    //li.append(li = $(`<div class="right-block">`)
                    //    .append($(`<h5 class ="product-name" title= "` + data.Name + ' ' + (data.Strength || '') + `" >`)
                    //        .append(Global.Click($(`<a href= "/ProductArea/Product/Details?Id=` + data.Id + `" > ` + data.Name + ` </a>`), ProductDetails.Render, data)))
                    //);
                    //li.append(`<div class="content_price">
                    //                            <span class ="price product-price">৳ `+ data.UnitSalePrice.toMoney() + ` </span>
                    //                        </div>`);

                    var oldPrice = '', price = data.UnitSalePrice;
                    //console.log([price], price);
                    if (data.Discount > 0) {
                        price = data.UnitSalePrice - data.UnitSalePrice.mlt(data.Discount).div(100);
                        oldPrice = '<del class="cross_price">৳ ' + Math.round(data.UnitSalePrice) + '</del>';
                    }
                    //console.log([data.Discount], data.Discount);
                    li.append(li = $('<div class="right-block">')
                        .append($('<h5 class ="product-name" title= "' + data.Name + ' ' + (data.Strength || '') + ' ' + (data.Category || '') + '" >')
                            .append(Global.Click($('<a href= "/ProductArea/Product/Details?Id=' + data.Id + '" > ' + data.Name + ' ' + (data.Strength || '') + ' ' + (data.Category || '') + ' </a>'), ProductDetails.Render, data)))
                    );
                    li.append('<div class="content_price"> <span class ="price product-price">৳ ' + price.toFloat(1) + ' </span><span class ="price product-price">' + oldPrice + '</span> </div>');


                };
                function setDiscountPercent(li, data) {
                    if (data.Discount > 0) {
                        li.append(li = $('<div class="group-price"><span class="product-new">' + data.Discount + '% </span></div>'));
                    }
                }
                function setLeftBlock(li, data) {
                    var quickView, leftBlock;
                    li.append(leftBlock = $('<div class="left-block">'));
                    leftBlock.append(Global.Click($('<a href="/ProductArea/Product/Details?Id=' + data.Id + '">' +
                        '<img class ="img-responsive" alt="product" src= "' + AppBase.GetImagePath(data) + '" style="max-height:205px;" />' +
                        '</a>'), ProductDetails.Render, data));
                    //leftBlock.append(quickView = $('<div class="quick-view">'));
                    //setQuickView(quickView, data);
                    //setAddToCart(leftBlock, data);
                };
                function setContent(ul, data) {
                    var li;
                    ul.append(li = $('<li class="col-sm-2 col-md-2 col-xs-6 main_dispaly_container">'));
                    li.append(li = $('<div class="main_dispaly">'));
                   
                    setLeftBlock(li, data);
                    setDiscountPercent(li, data);
                    setRightBlock(li, data);
                    //console.log(['', ul, data, li]);
                    setAddToCart(li, data);
                };
                function Bannerload(container, data) {
                    Global.CallServer('/BannerArea/Banner/GetBanner', function (response) {
                        if (!response.IsError) {
                            var item;
                            response.Data.each(function () {
                                item = {
                                    "Id": this[0],
                                    "Name": this[1],
                                    "Image": this[2],
                                };
                                //setLeftPanel(container, data, item);
                                setRightPanel(container, data);
                            });
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, {}, 'GET');
                };
                //function setLeftPanel(container, data, item) {
                //    container.append(`<div class="box-left">
                //                <div class="banner-img">
                //                    <a href="#"><img src="/Content/ImageData/Banner/Orginal/`+item.Image+`"></a>
                //                </div>
                //            </div>`);

                //};
                function setRightPanel(container, data) {
                    var ul, item;
                    //container.append($('<div class="box-right">').append(ul = $('<ul class="product-list row">')));
                    container.append($('<div>').append(ul = $('<ul class="product-list row">')));
                    data.each(function () {
                        item = {
                            "Id": this.Id || this[0],
                            "Name": this.Name || this[1],
                            "GenericName": this.GenericName || this[2],
                            "Strength": this.Strength ||this[3],
                            "UnitSalePrice": this.UnitSalePrice ||this[4],
                            "Discount": this.Discount ||this[5],
                            "ImagePath": this.ImagePath ||this[6],
                            "ImageType": this.ImageType || this[7],
                            "Category": this.Category || this[8],
                            "Suplier": this.Suplier || this[9],
                            "TotalStock": this.TotalStock || this[10],
                        };
                        setContent(ul, item);
                    });
                };
                function setWaiting(container) {
                    var elm;
                    container.append(container = $('<li class="col-sx-12 col-sm-4 col-md-3">'));
                    container.append(elm = $('<div class="product-container">'));
                    elm.append(elm = $('<img class="search_product_image" src="/Content/IqraService/Img/Spin-1s-80px.gif" />'));
                    return container;
                };
                function load(container, tab) {
                    var waiting = setWaiting(container);
                    Global.CallServer(tab.Url, function (response) {
                        if (!response.IsError) {

                            // setLeftPanel() and setRightPanel () is calling from Bannerload  Function

                            //setLeftPanel(container, response.Data);
                            //setRightPanel(container, data);
                            Bannerload(container, response.Data);
                            waiting.remove();
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, {}, 'GET');
                };
                this.Render = function (container, tab, data) {
                    container.empty();
                    resetTab(tab.index);
                    container.append(container = $('<div class="product-featured-tab-content">'));
                    container.append(container = $('<div id="sale_tab_container" class="tab-container">'));
                    container.append(container = $('<div class="tab-panel active">'));
                    if (data && data.each) {
                        //setLeftPanel(container, data);
                        if (window.appData && window.appData.Data && window.appData.Data.Data && window.appData.Data.Data.length) {
                            //AppBase.GetData(0)[5].each(function () {
                            //    //setRightPanel(container, data);
                            //});
                        } else {
                            Bannerload(container, data);
                        }
                        setRightPanel(container, data);
                    } else {
                        if (tab.datasource && tab.datasource.length) {
                            setRightPanel(container, tab.datasource);
                        } else {
                            load(container, tab);
                        }

                    }

                };
            }).call(view.TabContent = {}, view);
            (function (parent) {
                var view = { Parent: parent };
                function LoadNotice(elm, data) {
                    elm.append(elm = $('<div class="ticker-item"> ** ' + data.NoticeContent + '</div>'));
                };
                function load(container) {
                    Global.CallServer('/NoticeArea/Notice/GetNotice', function (response) {
                        if (!response.IsError) {
                            var item;
                            response.Data.each(function () {
                                item = {
                                    "Id": this[0],
                                    "Name": this[1],
                                    "IsDeleted": this[2],
                                    "NoticeContent": this[3],
                                };
                                if (item.IsDeleted != true) {
                                    LoadNotice(container, item);
                                }
                            });
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, {}, 'GET');
                };
                this.Render = function (container) {
                    view.Container = container.empty();
                    container.append(container = $('<div class="ticker-wrap">'));
                    container.append(elm = $('<div class="ticker-move">'));
                    if (window.appData && window.appData.Data && window.appData.Data.Data && window.appData.Data.Data.length) {
                        AppBase.GetData(6).each(function () {
                            LoadNotice(elm, this);
                        });
                    } else {
                        load(elm);
                    }
                    return view.Container
                };
            }).call(view.ContentNotice = {}, view);
            
            this.Render = function (container) {
                
                var menuContainer, contentContainer, subcategoryContainer;
                view.Container = container.empty();
                container.append(view.ContentNotice.Render($('<div class="tcontainer">')));
                container.append(container = $('<div class="container">'));
                container.append(container = $('<div class="category-featured electronic">'));
                container.append(menuContainer = $('<nav class="navbar nav-menu show-brand">'));
                container.append(container = $('<div class="product-featured clearfix">'));
                container.append(container = $('<div class="row">'));
                container.append(subcategoryContainer = $('<div class="col-sm-2 sub-category-wapper">'));
                container.append(contentContainer = $('<div class="col-sm-10 col-right-tab">'));
                
                view.NavbarMenu.Render(menuContainer, contentContainer);
                view.SubCategory.Render(subcategoryContainer, contentContainer);
                tabs && tabs[0] && tabs[0].elm && tabs[0].elm.click();
                return view.Container
            };
        }).call(view.ContentPage = {}, view);

        (function (parent) {
            var view = { Parent: parent };
            function createCol(container, cls, dataUrl, imgUrl) {
                container.append(container = $('<div class="col-sm-6 item-' + cls + '">'));
                container.append(container = $('<div class="banner-boder-zoom">'));
                container.append(container = $('<a href="' + (dataUrl || '#') + '"><img class="img-responsive" alt="ads" src="' + imgUrl + '"></a>'));
            };
            function getCls() {
                switch (AppService.Img.LazzPolli.length) {
                    case 1:
                        return 'col-md-12';
                    case 2:
                        return 'col-md-6 col-sm-6';
                    case 3:
                    case 9:
                        return 'col-md-4 col-sm-4 col-xs-4';
                    case 4:
                    case 5:
                    case 8:
                        return 'col-md-3 col-sm-6';
                    case 6:
                    case 7:
                        return 'col-md-2 col-sm-4';

                }
            };
            function createBanner(container) {
                var elm, cls = getCls();
                container.append($('<h2 class="page-heading"><span class="page-heading-title">Lazz Polli Resort</span></h2>'));
                container.append(container = $('<div class="row">'));
                container.append(container = $('<div class="banner-boder-zoom">'));
                AppService.Img.LazzPolli.each(function () {
                    container.append(elm = $('<div class="' + cls + '">'));
                    elm.append(elm = $('<a href="' + AppService.Link.Banner.LazzPollyUrl + '">'));
                    elm.append(elm = $('<img class="img-responsive" alt="ads" src="' + (this + '') + '"  style="margin: 0px auto;">'));
                });
            };
            //(function (parent) {
            //    var view = { Parent: parent };
            //    function createItem(container, data) {
            //        var elm;
            //        container.append(container = $('<li class="col-xs-6 col-sm-6 col-md-4 services2-item">'));
            //        container.append(container = $('<div class="service-wapper">'));
            //        container.append(container = $('<div class="row">'));
            //        container.append(elm = $('<div class="col-sm-6 image">'));
            //        elm.append($('<div class="icon_index"><img src="' + data.Icon + '" alt="service"></div>'));
            //        elm.append($('<h3 class="title"><a href="#">' + data.Title + '</a></h3>'));
            //        container.append($('<div class="col-sm-6 text"> ' + data.Text + ' </div>'));
            //    };
            //    this.Render = function (container) {
            //        container.append(container = $('<div class="services2">'));
            //        container.append(container = $('<ul>'));
            //        AppService.Services.each(function () {
            //            createItem(container, this);
            //        });
            //        return view.Container
            //    };
            //}).call(view.Services = {}, view);

            //(function (parent) {
            //    var view = { Parent: parent };
            //    function veiwBlog(data) {
            //        AppBlog.Render(view.Parent.Parent.Container, data.Url);
            //    };
            //    function createItem(container, data) {
            //        var elm;
            //        container.append(container = $('<div class="owl-item cloned" style="width: 270px; margin-right: 30px;">'));
            //        container.append(container = $('<li>'));
            //        container.append(elm = $('<div class="post-thumb image-hover2"></div>'));
            //        elm.append(Global.Click($('<a href="' + data.Url + '"><img src="' + data.Img + '" alt="Blog"></a>'), veiwBlog, data));
            //        container.append(container = $('<div class="post-desc">'));
            //        container.append(elm = $('<h5 class="post-title">'));
            //        elm.append(Global.Click($('<a href="' + data.Url + '">' + data.Title + '</a>'), veiwBlog, data));
            //        container.append('<div class="post-meta"><span class="date">' + data.CreatedAt + '</span></div>');
            //        container.append(Global.Click($('<div class="readmore"><a href="' + data.Url + '">Readmore</a></div>'), veiwBlog, data));
            //    };
            //    this.Render = function (container) {
            //        var menuContainer, contentContainer, subcategoryContainer;
            //        container.append(container = $('<div class="blog-list">'));
            //        container.append('<h2 class="page-heading"><span class="page-heading-title">From the blog</span></h2>');
            //        container.append(container = $('<div class="blog-list-wapper">'));
            //        container.append(container = $('<ul class="owl-carousel owl-theme owl-loaded">'));
            //        container.append(container = $('<div class="owl-stage-outer">'));
            //        container.append(container = $('<div class="owl-stage" style="width: 3600px;">'));
            //        AppService.BlogList.each(function () {
            //            createItem(container, this);
            //        })
            //        return view.Container
            //    };
            //}).call(view.Blog = {}, view);

            this.Render = function (container) {
                view.Container = container.empty();
                container.append(container = $('<div class="container">'));
                createBanner(container);
                //view.Blog.Render(container);
                //view.Services.Render(container);
                return view.Container
            };
        }).call(view.ContentWrap = {}, view);
       
       
        this.Render = function (container) {
            view.Container = container.empty();

            AppBase.State.Set({
                Param: [container],
                Component: parent.Home,
            }, 'HomePage', '/');

            resetMenu(0);
            BodyParent.NavTopMenu.Set('home');
            container.append(view.Slider.Render($('<div id="home-slider">')));
           
            container.append(view.ContentPage.Render($('<div class="content-page">')));
            container.append(view.ContentShopPage.Render($('<div class="content-page">')));
            container.append(view.ContentWrap.Render($('<div id="content-wrap">')));
            

            return view.Container
        };
    }).call(view.Home = {}, view);

    (function (parent) {
        var view = { Parent: parent }, images = [], formModel = {}, location = {};

        function getShipingAddress() {
            var model = {
                Name: formModel.CustomerName,
                Email: formModel.Email,
                Number: formModel.Phone,
                Address: formModel.Address
            };
            if (location && location.lat && location.lng) {
                model.Lat = location.lat;
                model.Lng = location.lng;
            }
            return model;
        };
        function getImageId() {
            var list = [];
            images.each(function () {
                list.push(this.Id);
            });
            return list;
        };
        function getModel() {
            var itemModel = view.Grid.Get(),
                model = {
                    OrderNo: formModel.OrderNo,
                    PaymentMethod: 'CashOnDelivery',
                    TotalItem: itemModel.List.length,
                    TotalQuantity: itemModel.TotalQnt,
                    PayableAmount: 0,
                    TotalAmount: 0,
                    PaidAmount: 0,
                    DiscountType: 'Default',
                    Discount: 0,
                    DiscountTotal: 0,
                    Status: "Pending",
                    From: "Request Order",
                    FileCount: images.length,
                    IconPath: '',
                    Remarks: formModel.Remarks,
                    ActivetyId: ActivityId,
                    Items: itemModel.List,
                    ImgId: getImageId(),
                    Shipping: getShipingAddress()
                };
            if (model.ImgId && model.ImgId.length) {
                model.IconPath = images[0].IconPath;
            }
            //public OrderShippingModel Shipping { get; set; }
            return model;
        };
        function isValid(model) {
            var pattern = /^(?:\+88|01)?(?:\d{11}|\d{13})$/;
            if (!formModel.Phone || !pattern.test(formModel.Phone)) {
                alert('Please Enter a Bangladeshi Phone number.');
                return false;
            }
            if (model.TotalItem <= 0 && model.ImgId.length == 0) {
                alert('Please select at least one product Or Upload a Prescription.');
                return false;
            }
            if (!formModel.CustomerName) {
                alert('Please enter your name.');
                return false;
            }
            if (!formModel.Phone) {
                alert('Please enter your phone.');
                return false;
            }
            if (!formModel.Address) {
                alert('Please enter your shiping address.');
                return false;
            }

            return true;
        };
        function save(model) {
            //if (discountStatus > 0) {

            var model = model || getModel();
            if (!isValid(model)) {
                return;
            }
            //console.log(['formModel', formModel, images, view.Grid.Get()]);
            Global.Busy();
            Global.CallServer('/ProductOrderArea/ProductOrder/Add', function (response) {
                Global.Free();
                if (!response.IsError) {
                    //reset();
                    response.Data.Number = formModel.Phone;
                    BodyParent.View.OrderInfo.Render(BodyParent.Container, response.Data);

                } else if (response.Id == -1) {
                    window.AppComponents.LogIn.Render(save, model);
                } else {
                    alert(response.Msg || 'Errors!!!!!.');
                }
            }, function () {
                Global.Free();
            }, model);
            //} else {
            //    alert('Please select a payment type.');
            //}
        };

        function setNotice(container) {

            container.append('<div class="notice"><h4 class="SearchFont SearchPrice">Note: Product availability & price will be confirmed over Phone/E-mail/Whatsapp.' + "<br>" + 'Delivery Charge within Dhaka City 80TK & outside Dhaka 120TK.</h4></div>');


        };
        function setAdd(container) {
            container.append(container = $('<div class="empty_style row" style="margin-top: 20px">'));
            getSection(container, formModel, 'Name', 'Ex. Napa Tab.', 'col-md-3');
            getSection(container, formModel, 'Strength', 'Ex. 500 mg', 'col-md-3');
            getSection(container, formModel, 'Quantity', 'Quantity In Pcs', 'col-md-3');
            container.append(container = $('<div class="col-md-3">'));
            container.append(Global.Click($('<button class="btn btn_cancel btn-success btn-default btn-round" style="width: 100%;" type="button"><span class="glyphicon glyphicon-save"></span> Add</button>'), view.Grid.Add));
        };
        function setPersonalInf(container) {
            var elm;
            container.append(container = elm = $('<div class="empty_style row">'));
            getSectionWithTitle(container, formModel, 'CustomerName', 'Your Name', 'col-md-4 col-sm-6');
            getSectionWithTitle(container, formModel, 'Email', 'Your E-Mail (Optional)', 'col-md-4 col-sm-6');
            getSectionWithTitle(container, formModel, 'Phone', 'Your Number', 'col-md-4 col-sm-6');
            //getSectionWithTitle(container, formModel, 'Address', 'Your Address');

            container = elm;
            container.append(container = $('<div class="col-md-12 col-sm-12">'));
            container.append('<div><label>Your Address</label></div>');
            container.append(container = $('<div>'));
            container.append(Global.AutoBind2(formModel, $('<textarea class="form-control" placeholder="Your Address">'), 'Address'));

            container = elm;
            container.append(container = $('<div class="col-md-12 col-sm-12">'));
            container.append('<div><label>Description (Optional)</label></div>');
            container.append(container = $('<div>'));
            container.append(Global.AutoBind2(formModel, $('<textarea class="form-control" placeholder="Description (Optional)">'), 'Remarks'));

        };
        function setIsAggreed(container) {
            container.append(elm = $('<div class="" style="text-align: center; margin: 15px;">'));
            elm.append(elm = $('<label>'));
            elm.append(Global.AutoBind2(formModel, $('<input type="radio">'), 'IsAggreed'));
            elm.append(' I have read and agreed to the <a href="/Home/TermsCondition"> Terms and conditions </a>');
            //elm.append(' I have read and agreed to the' + '<a href="/Home/TermsCondition">' + ' Terms and conditions' + '</a>');


        };
        (function () {
            var imgContainer;
            function onDelete(model) {
                if (model.IsError) {
                    model.elm.remove();
                    return;
                }
                if (model.IsCompleted) {
                    Global.Controller.Call({
                        url: IqraConfig.Url.Js.WarningController,
                        functionName: 'Show',
                        options: {
                            name: 'Delete',
                            msg: 'Do you want to delete?',
                            save: '/ProductOrderArea/ProductOrder/RemoveFile',
                            data: { Id: model.Id },
                            onsavesuccess: function () {
                                model.elm.remove();
                                var list = [];
                                images.each(function () {
                                    if (this.Id != model.Id) {
                                        list.push(this);
                                    }
                                });
                                images = list;
                            }
                        }
                    });
                } else {
                    model.request.Cancel();
                    model.elm.remove();
                }
                model.IsCompleted = true;
            };
            function save(model) {
                model.request = Global.Uploader.upload({
                    data: model.Data,
                    url: '/ProductOrderArea/ProductOrder/AddFile',
                    onProgress: function (data) {
                        model.Layer.css({ width: parseInt((data.loaded / data.total) * 100) + 'px' });
                    },
                    onComplete: function (response) {
                        model.IsCompleted = true;
                        if (!response.IsError) {
                            model.Layer.remove();
                            model.Id = response.Data;
                            model.IconPath = response.Msg;
                            images.push(model);
                            return;
                        } else if (response.Id == -1) {
                            window.AppComponents && window.AppComponents.LogIn.Render(function () { save(model); }, function () {
                                //console.log('model', model)
                                model.IsError = true;
                                model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                            });
                        } else {
                            model.IsError = true;
                            model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                        }
                    },
                    onError: function (response) {
                        model.IsError = true;
                        model.IsCompleted = true;

                        model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                    }
                });
            }
            function createView(src, file) {
                var layer = $('<div style="position: absolute; z-index: 1; background-color: rgba(20, 20, 20, 0.7); height: 100px; top: 0px; right: -10px; width: 100px;"></div>');
                var btn = $('<div class="btn_delete" style="position: absolute; right: -10px; top: -3px;z-index: 2;"><span class="icon_container" style="border-radius: 50%; padding: 0px 1px; border: 2px solid rgb(255, 255, 255); cursor: pointer; font-size: 0.8em;"> <span class="glyphicon glyphicon-remove"></span></span></div>');
                var img = $('<img style="max-width:100px; max-height:100px;" />'), elm = $('<div class="col-md-3 image_item"></div>').append(btn).append(img).append(layer);
                img.attr('src', src);
                var model = {
                    Id: Global.Guid(),
                    elm: elm,
                    Layer: layer,
                    Data: {
                        Img: { IsFile: true, File: file },
                        Id: '00000000-0000-0000-0000-000000000000',
                        ActivityId: ActivityId
                    }
                };
                Global.Click(btn, onDelete, model);
                imgContainer.append(elm);
                save(model);
            };
            function onChange() {
                var input = this;
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        createView(e.target.result, input.files[0]);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            };
            this.Render = function (container) {
                var elm;
                container.append(container = $('<div class="empty_style row">'));
                container.append(elm = $('<div class="col-md-3">'));
                elm.append(elm = $('<div>'));
                elm.append('<button class="btn btn_upload" type="button" style="width: 100%;"><span class="glyphicon glyphicon-plus"> </span><span> Upload Prescription Here</span></button>');
                elm.append($('<input id="btn_image" class="btn btn_upload btn-white btn-default btn-round" style="position: absolute; left: 0px; top: 0px; opacity: 0; padding: 3px;" type="file">').change(onChange));
                container.append(container = $('<div class="col-md-9">'));
                container.append(imgContainer = $('<div class="img_preview row">'));
                return view.Container
            };
        }).call(view.Upload = {});
        (function () {
            var gridModel, dataSource = [];

            function onRemove(model) {
                var list = [];
                dataSource.each(function () {
                    if (model.DataId != this.DataId) {
                        list.push(this);
                    }
                });
                dataSource = list;
                $(this).closest('tr').remove();
            };
            function rowBound(elm) {
                //console.log(['rowBound', this, elm, elm.find('.actions')]);
                elm.find('.fa-times');
            };
            this.Add = function () {
                console.log(["formModel.Quantity", formModel.Quantity]);
                var qnt = parseInt(formModel.Quantity || '0', 10);
                if (qnt > 0) {
                    var model = {};
                    model.DataId = Global.Guid();
                    model.Actions = 'Delete';
                    model.Name = formModel.Name;
                    model.Strength = formModel.Strength;
                    model.Quantity = formModel.Quantity;
                    gridModel.Add(model);
                    dataSource.push(model);
                    formModel.Name = '';
                    formModel.Strength = '';
                    formModel.Quantity = '';
                }
                else {
                    alert('Please Enter Quantity in Pieces .');
                }
            };
            this.Render = function (container) {
                dataSource = [];
                container.append(container = $('<div class="grid_container" style="margin: 15px;">'));
                Global.Grid.Bind({
                    elm: container,
                    columns: [
                        { field: 'Name' },
                        { field: 'Strength' },
                        { field: 'Quantity' },
                        { field: 'Actions', className: 'actions', click: onRemove }
                    ],
                    dataSource: [],
                    page: { 'PageNumber': 1, 'PageSize': 1000, showingInfo: ' {0}-{1} of {2} Products' },
                    pagger: false,
                    rowBound: rowBound,
                    onComplete: function (model) {
                        gridModel = model;
                    },
                    Responsive: false
                });
                return view.Container
            };
            this.Get = function () {
                var totalQnt = 0, totalPrice = 0, list = [];
                dataSource.each(function () {
                    list.push({
                        DiscountType: this.Name,
                        PromoCode: this.Strength,
                        Quantity: this.Quantity
                    });
                });
                return { List: list, TotalQnt: totalQnt, TotalPrice: totalPrice };
            };
        }).call(view.Grid = {});
        this.Render = function (container) {
            var elm;
            view.Container = container.empty();
            images = [];
            location = {};
            AppBase.State.Set({
                Param: [container],
                Component: parent.RequestOrder,
            }, 'RequestOrderPage', '/RequestOrder');
            //console.log(['view.RequestOrder', view.RequestOrder]);
            resetMenu(1);
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Request Order', view.Parent.Home.Render, view.Parent.Home.Container);

            container.append(container = $('<div class="request_product">'));
            setNotice(container);
            setAdd(container);
            view.Grid.Render(container);
            setPersonalInf(container);
            view.Upload.Render(container);
            setIsAggreed(container);
            container.append(container = $('<div class="text-center formFooter FooterFormMenu">'));
            container.append(Global.Click($('<button class="btn btn-success btn-default btn-round" type="button" style="margin-bottom:15px"><span class="glyphicon glyphicon-upload"></span> Send </button>'), save));
            return view.Container
        };
    }).call(view.RequestOrder = {}, view);

    (function (parent) {
        var formModel = {}, deliveryStatus = 0, nameInput, qntInput, discountStatus = 0,
            view = { Parent: parent, FormModel: formModel }, images = [], location = {};
        function reset() {

        };
        function getShipingAddress() {
            var model = {
                Name: formModel.Name,
                Email: formModel.Email,
                Number: formModel.Phone,
                Address: formModel.Address,
                Name: formModel.Name,
            };
            if (location && location.lat && location.lng) {
                model.Lat = location.lat;
                model.Lng = location.lng;
            }
            return model;
            //public Guid ThanaId { get; set; }
            //public Guid DistictId { get; set; }
            //public string Remarks { get; set; }
        };
        function getImageId() {
            var list = [];
            images.each(function () {
                list.push(this.Id);
            });
            return list;
        };
        function getModel() {
            var itemModel = view.Grid.Get(),
                model = {
                    OrderNo: formModel.OrderNo,
                    PaymentMethod: discountStatus == 1 ? 'CashOnDelivery' : 'Online',
                    TotalItem: itemModel.List.length,
                    TotalQuantity: itemModel.TotalQnt,
                    PayableAmount: formModel.TotalAmount,
                    //PayableAmount: discountStatus == 1 ? formModel.TotalAmount : formModel.DiscountedAmount,
                    TotalAmount: formModel.TotalAmount,
                    //ShippingZone: deliveryStatus == (1) ? ('Inside Dhaka') : ((2) ? ('Outside Dhaka') : ('Emergency Inside Dhaka')),
                    ShippingZone: deliveryStatus == 1 ? 'Inside Dhaka' : 'Outside Dhaka',
                    ShippingCharge: formModel.DeliveryCharge,
                    PaidAmount: 0,
                    DiscountType: 'Default',
                    Discount: 0,
                    DiscountTotal: discountStatus == 1 ? 0 : formModel.OnlinePaymentDiscount,
                    Status: "Pending",
                    From: "Order Now",
                    FileCount: images.length,
                    IconPath: '',
                    Remarks: formModel.Remarks,
                    ActivetyId: ActivityId,
                    Items: itemModel.List,
                    ImgId: getImageId(),
                    Shipping: getShipingAddress()
                };
            if (model.ImgId && model.ImgId.length) {
                model.IconPath = images[0].IconPath;
            }
            return model;
        };
        function isValid(model) {
            var pattern = /^(?:\+88|01)?(?:\d{11}|\d{13})$/;
            if (model.TotalItem <= 0) {
                alert('Please select at least one product.');
                return false;
            }
            if (!formModel.Name) {
                alert('Please enter your name.');
                return false;
            }
            if (!formModel.Phone || !pattern.test(formModel.Phone)) {
                //console.log("[formModel.Phone]", formModel.Phone);
                //console.log("[formModel.Phone.length]", formModel.Phone.length);
                alert('Please Enter a Bangladeshi Phone number.');
                return false;
            }
            if (!formModel.Address) {
                alert('Please enter your shiping address.');
                return false;
            }
            return true;
        };
        function save(model) {
            if (discountStatus > 0) {
                if (deliveryStatus > 0 && formModel.DeliveryCharge > 0) {
                    var model = model || getModel();
                    if (!isValid(model)) {
                        return;
                    }
                    Global.Busy();
                    Global.CallServer('/ProductOrderArea/ProductOrder/Add', function (response) {
                        Global.Free();
                        if (!response.IsError) {
                            //reset();
                            if (model.PaymentMethod === 'Online') {

                                window.location.href = response.Data;
                            } else {
                                //alert(formModel.Address + ' Ordered Succesfully');
                                response.Data.Number = formModel.Phone;
                                BodyParent.View.OrderInfo.Render(BodyParent.Container, response.Data);
                            }
                        } else if (response.Id == -1) {
                            window.AppComponents.LogIn.Render(save, model);
                        } else {
                            alert(response.Msg || 'Errors!!!!!.');
                        }
                    }, function () {
                        Global.Free();
                    }, model);
                } else { alert('Please select a shipping zone.'); }
            } else {
                alert('Please select a payment type.');
            }

        };
        function populate() {
            formModel.Amount = formModel.PayablePrice || 0;
            formModel.DeliveryCharge = formModel.DeliveryCharge || 0;
            formModel.TotalAmount = formModel.Amount + formModel.DeliveryCharge;
            formModel.OnlinePaymentDiscount = formModel.Amount.mlt(0);
            formModel.DiscountedAmount = formModel.TotalAmount - formModel.OnlinePaymentDiscount;
        };
        function setLeftBlock(container) {
            container.append(container = $('<div class="col-md-6 SearchFont SearchProductName">'));
            container.append(container = $('<div class="External_Block">' +
                '<p class="External_Block_Title">You may request the products those </p>' +
                '<p class="External_Block_Title"> are not available here</p>' + '</div>'));
            container.append(Global.Click($('<button class="External_Block_Button" type="button">REQUEST ORDER</button>'), function () {
                parent.RequestOrder.Render(BodyParent.Container);
            }));
        };
        function setRightBlock(container) {
            container.append(container = $('<div class="col-md-6 SearchFont SearchProductName">'));
            container.append(container = $('<div class="External_Block">' +
                '<p class="External_Block_Title">Do not Know How to Order ?</p>' +
                '<p class="External_Block_Title">Watch Here</p>' + '</div>'));
            container.append(Global.Click($('<button class="External_Block_Button" type="button">HOW TO ORDER</button>'), function () {
                parent.HowToOrder.Render(BodyParent.Container);
            }));
        };
        function setExternalLink(container) {
            container.append(container = $('<div class="External_link">'));
            container.append(container = $('<div class="row">'));
            setLeftBlock(container);
            setRightBlock(container);
        }
        function setNotice(container) {

            container.append('<div class="notice"><h4 class="SearchFont SearchPrice">Note: Product availability & price will be confirmed over Phone/E-mail/Whatsapp.' + "<br>" + 'Delivery Charge within Dhaka City 80TK & outside Dhaka 120TK.</h4></div>');

        };
        function setFooterNotice(container) {

            container.append('<div class="notice"><p class="OrderNotice">*** Please pay first for outside Dhaka delivery (ঢাকার বাইরে অর্ডারের ক্ষেত্রে ক্যাশ অন ডেলিভারি প্রযোজ্য নয়)</p>' +
                '<p class="OrderNotice">*** Please pay the delivery charge first for inside Dhaka delivery (Cash on Delivery) (ঢাকার ভিতর ক্যাশ অন ডেলিভারি এর ক্ষেত্রে ডেলিভারি চার্জ আগে প্রদান করতে হবে)</p>' + '</div >');

        };
        function setPersonalInf(container) {


        };
        function setTotalInfo(container) {
            container.append(container = $('<div class="empty_style row">'));
            getSectionWithLabel(container, formModel, 'TotalItem', 'Total Item');
            getSectionWithLabel(container, formModel, 'TotalQuantity', 'Total Quantity');
            getSectionWithLabel(container, formModel, 'TotalPrice', 'Total Price');
            getSectionWithLabel(container, formModel, 'PayablePrice', 'Payable Price');
        };
        function setCustomerInfo(container) {

            getSectionWithTitle(container, formModel, 'Name', 'Your Name');
            getSectionWithTitle(container, formModel, 'Email', 'Your E-Mail (Optional)');
            getSectionWithTitle(container, formModel, 'Phone', 'Your Number');
        };
        function setIsAggreed(container) {
            container.append(elm = $('<div class="" style="text-align: center; margin: 15px;">'));
            elm.append(elm = $('<label>'));
            elm.append(Global.AutoBind2(formModel, $('<input type="radio">'), 'IsAggreed'));
            //elm.append(' I have read and agreed to the' + '<a href="/Home/TermsCondition">'+' Terms and conditions'+'</a>');
            elm.append(' I have read and agreed to the <a href="/Home/TermsCondition"> Terms and conditions </a>');
        };
        (function (parent) {
            var view = { Parent: parent }, formModel, discountTr = [], discountContainer, tbody;

            function removeDiscount() {
                discountTr[0] && discountTr[0].remove();
                discountTr[1] && discountTr[1].remove();
                discountStatus = 1;
            }

            function InsideDelivery() {

                deliveryStatus = 1;
                formModel.Amount = formModel.PayablePrice || 0;
                formModel.DeliveryCharge = 80;
                //console.log("[formModel.DeliveryCharge]", formModel.DeliveryCharge);
                formModel.TotalAmount = formModel.Amount + formModel.DeliveryCharge;

                //console.log("formModel.Amount", formModel.Amount);
            }
            function OutsideDelivery() {
                deliveryStatus = 2;
                formModel.Amount = formModel.PayablePrice || 0;
                formModel.DeliveryCharge = 120;
                formModel.TotalAmount = formModel.Amount + formModel.DeliveryCharge;
            }
            //function EmergencyDelivery() {
            //    deliveryStatus = 3;
            //    formModel.Amount = formModel.PayablePrice || 0;
            //    formModel.DeliveryCharge = 150;
            //    formModel.TotalAmount = formModel.Amount + formModel.DeliveryCharge;
            //}
            function setDiscount(container) {
                var elm, onlinePaymentDiscount = formModel.OnlinePaymentDiscount || 0,
                    discountedAmount = formModel.DiscountedAmount || 0;
                discountStatus = 2;
                discountTr[0] && discountTr[0].remove();
                discountTr[1] && discountTr[1].remove();

                //container.append(discountTr[0] = elm = $(`<tr><td colspan="3"><strong>Online Payment Discount </strong></td></tr>`));
                //elm.append(elm = $('<td colspan="2" style="color:red">'));
                //elm.append(Global.AutoBind(formModel, $(`<strong>0.00</strong>`), 'OnlinePaymentDiscount'));

                //container.append(discountTr[1] = elm =  $(`<tr><td colspan="3"><strong>Net Total </strong></td></tr>`));
                //elm.append(elm = $('<td colspan="2" style="color:red">'));
                //elm.append(Global.AutoBind(formModel, $(`<strong>0.00</strong>`), 'DiscountedAmount'));

                formModel.DiscountedAmount = discountedAmount;
                formModel.OnlinePaymentDiscount = onlinePaymentDiscount;
            };
            function setAmount(container) {
                var elm;
                container.append(elm = $('<tr><td colspan="3">Amount (tax incl.)</td></tr>'));
                elm.append(Global.AutoBind(formModel, $('<td colspan="2">0.00</td>'), 'Amount', 2));

                container.append(elm = $('<tr><td colspan="3">Delivery Charge</td></tr>'));
                elm.append(Global.AutoBind(formModel, $('<td colspan="2">0.00</td>'), 'DeliveryCharge', 2));

                container.append(elm = $('<tr><td colspan="3"><strong>Total Amount </strong></td></tr>'));
                elm.append(Global.AutoBind(formModel, $('<td colspan="2">0.00</td>'), 'TotalAmount', 2));

            };
            function setSummary(container) {
                container.append(container = $('<table class="table table-bordered table-responsive cart_summary">'));
                container.append(container = tbody = $('<tbody>'));
                setAmount(container);
            };
            function setMethod(container) {
                var elm;
                container.append(container = $('<div class="row"  style="margin: auto;">'));
                container.append(elm = $('<div class="col-md-6  box-border" id="cash_radio_button">'));
                elm.append(elm = $('<label class="Method_Selector">'));
                elm.append(elm = $('<input type="radio" name="radio_4" id="radio_button_5" />')).append(' Cash on Delivery');
                elm.change(function () {
                    if (!elm.prop('checked')) {
                        removeDiscount();
                    }
                });
                container.append(elm = $('<div class="col-md-6  box-border">'));
                elm.append(elm = $('<label class="Method_Selector">'));
                elm.append(elm = $('<input type="radio" name="radio_4" id="radio_button_6" />')).append(' Online Payments');
                elm.change(function () {
                    if (elm.prop('checked')) {
                        setDiscount(tbody);
                    }
                });
            };

            function setDelivery(container) {
                var elm;
                container.append(container = $('<div class="row"  style="margin: auto;">'));
                container.append(elm = $('<div class="col-md-6  box-border">'));
                elm.append(elm = $('<label class="Method_Selector">'));
                elm.append(elm = $('<input type="radio" name="radio_5" id="radio_button_7" />')).append(' Inside Dhaka');
                elm.change(function () {
                    if (!elm.prop('checked')) {
                        $("#cash_radio_button").show();
                        $("#radio_button_5").prop('checked', false);
                        $("#radio_button_6").prop('checked', false);
                        InsideDelivery();
                        discountStatus = 0;
                    }
                });
                container.append(elm = $('<div class="col-md-6  box-border">'));
                elm.append(elm = $('<label class="Method_Selector">'));
                elm.append(elm = $('<input type="radio" name="radio_5" id="radio_button_8" />')).append(' Outside Dhaka');
                elm.change(function () {
                    if (elm.prop('checked')) {
                        $("#cash_radio_button").hide();
                        $("#radio_button_5").prop('checked', false);
                        $("#radio_button_6").prop('checked', true);
                        setDiscount(tbody);
                        OutsideDelivery();
                    }
                });
                //container.append(elm = $('<div class="col-md-4  box-border">'));
                //elm.append(elm = $('<label class="Method_Selector">'));
                //elm.append(elm = $('<input type="radio" name="radio_5" id="radio_button_9" />')).append(' Emergency Delivery Inside Dhaka');
                //elm.change(function () {
                //    if (elm.prop('checked')) {
                //        $("#cash_radio_button").show();
                //        $("#radio_button_5").prop('checked', false);
                //        $("#radio_button_6").prop('checked', false);
                //        EmergencyDelivery();
                //        discountStatus = 0;
                //    }
                //});

            };

            this.Render = function (container, fmdModel) {
                discountStatus = 0;
                formModel = fmdModel;
                container.append(container = $('<div class="order-detail-content" style="padding: 15px;">'));
                setSummary(container);
                setDelivery(container);
                container.append('<div class="notice"><p class="OrderNotice">*** সকাল ১০ টা থেকে ৭ টার মধ্যে অর্ডার করলে ২৪ থেকে ৪৮ ঘন্টার মধ্যে ডেলিভারি</p>');
                setMethod(container);
            };
        }).call(view.Payment = {}, view);
        (function (parent) {
            var view = { Parent: parent };
            function addItem() {
                var model = view.Search.GetModel();
                if (model) {
                    var qnt = parseInt(formModel.Quantity || '0', 10);
                    if (qnt > 0) {
                        model.Quantity = qnt;
                        model.TotalPrice = formModel.Price;
                        view.Parent.Grid.Add(model);
                        formModel.ProductName = '';
                        //nameInput.select();
                        nameInput.focus();
                    } else {
                        alert('Please set product Quantity.');
                    }
                } else {
                    alert('Please search for a product.');
                }
            };
            (function () {
                var searchContainer, isHidePrevented, self = {}, selectedModel,
                    searchTimeout, searchRequest, lastText, filter,
                    filterModel = { "field": "Name", "value": "", "Operation": 6 };

                function hide() {
                    if (selectedModel && selectedModel.Name != formModel.ProductName) {
                        selectedModel = none;
                    }
                    setTimeout(function () {
                        if (isHidePrevented) {
                            isHidePrevented = false;
                        } else {
                            searchContainer.hide(100);
                        }
                    }, 50);
                };
                function prevent(n) {
                    n.stopPropagation();
                    n.preventDefault();
                };
                function show() {
                    searchContainer.show(100);
                };
                function search() {
                    //console.log(['searchRequest', searchRequest]);
                    var text = formModel.ProductName;
                    if (text == lastText) {
                        return;
                    }

                    filter = [];
                    if (text) {
                        filterModel.value = text;
                        filter = [filterModel];
                    }
                    lastText = text;

                    var query;
                    if (text) {
                        query = [];
                        text.split(' ').each(function () {
                            text = (this + '').trim();
                            if (text && text.length > 0) {
                                query.push(text);
                            }
                        });
                        if (query.length == 0) {
                            query = none;
                        }
                    }
                    nameInput.addClass('loading');
                    searchRequest = Global.CallServer('/ProductArea/Product/Search', function (response) {
                        nameInput.removeClass('loading');
                        if (!response.IsError) {
                            self.View.Create(response.Data);
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, { 'PageNumber': 1, 'PageSize': 5, Query: query }, 'POST');
                };
                function setEvents(input) {
                    //console.log([input, 'input']);
                    input.focus(function () {
                        searchContainer.show(100);
                    }).blur(function () {
                        hide();
                    }).keyup(function () {
                        if (searchTimeout) {
                            clearTimeout(searchTimeout);
                        }
                        searchTimeout = setTimeout(function () {
                            search();
                        }, 150);
                    }).click(prevent).mousedown(function prevent(n) {
                        n.stopPropagation();
                    });
                    $(document).click(hide).mousedown(hide);
                    return input;
                };
                function onChange() {
                    //console.log(['onChange', this]);
                };
                (function (view) {
                    var availability = '';
                    function add(item) {
                        //console.log(['addToCard', item, this]);
                        //isHidePrevented = true;
                        formModel.ProductName = item.Name;
                        formModel.Price = formModel.UnitSalePrice = item.UnitSalePrice;
                        selectedModel = item;
                        hide();
                        qntInput.focus();
                    };
                    function create(container, item) {
                        //data.TotalDiscount = data.Price.mlt(data.Discount).div(100);
                        var price = item.UnitSalePrice, del = '', tr;
                        if (item.Discount) {
                            price = price - price.mlt(item.Discount).div(100);
                            del = '<del class="SearchDelPrice">&nbsp;৳ ' + item.UnitSalePrice.toMoney() + '</del>'
                        }

                        //if (item.TotalStock > 0) {
                            tr = Global.Click($('<tr><td>' +
                                '<span class="SearchProductName">' + item.Name + '</span>&nbsp;' +
                                del +
                                '<span class="SearchPrice">&nbsp;৳ ' + price.toMoney() + '</span>' +
                                //'&nbsp;<span class="search_in_stock"> In Stock </span><br>' +
                                '<span class="SearchProps">Strength - ' + item.Strength + ', Type - ' + item.Category + '</span>' +
                                '</td></tr>'), add, item);
                        //}
                        //else {
                        //    tr = $('<tr><td style="background-color: #f9f9f9;opacity: 0.6;">' +
                        //        '<span class="SearchProductName">' + item.Name + '</span>&nbsp;' +
                        //        del +
                        //        '<span class="SearchPrice">&nbsp;৳ ' + price.toMoney() + '</span>' +
                        //        '&nbsp;<span class="search_out_stock"> Out of Stock </span><br>' +
                        //        '<span class="SearchProps">Strength - ' + item.Strength + ', Type - ' + item.Category + '</span>' +
                        //        '</td></tr>');
                        //}

       
                        tr.mousedown(function (e) {
                            isHidePrevented = true;
                        });
                        container.append(tr);
                    };
                    view.Create = function (data) {
                        searchContainer.empty();
                        var item;
                        data.each(function () {

                            item = {
                                "Id": this[0],
                                "Name": this[1],
                                "GenericName": this[2],
                                "Strength": this[3],
                                "UnitSalePrice": this[4],
                                "Discount": this[5],
                                "ImagePath": this[6],
                                "ImageType": this[7],
                                "Category": this[8],
                                "Suplier": this[9],
                                "TotalStock": this[10],
                            };
                            create(searchContainer, item);
                        });
                        console.log(['item', item]);
                        searchContainer.show();
                    };
                })(self.View = {});
                this.Render = function (container) {
                    var elm;
                    container.append(container = $('<div class="col-md-3 col-sm-6">'));
                    container.append(nameInput = setEvents(Global.AutoBind2(formModel, $('<label> Trade Name | Generic Name</label><input class="form-control" placeholder="Trade Name | Generic Name" type="text">'), 'ProductName')));
                    container.append(container = $('<div class="search_container" style="position: relative;">'));
                    container.append(container = Global.Click($('<table class="table table-bordered table-striped UrgentSearchTable" style="position: absolute; z-index: 1; background: white none repeat scroll 0% 0%; left: 0px; top: 0px;" cellspacing="0">'), function () {
                        //console.log(['Click', isHidePrevented]);
                        isHidePrevented = true;
                    }).mousedown(prevent));
                    container.append(searchContainer = $('<tbody>'));
                    return searchContainer
                };
                this.GetModel = function () {
                    //console.log(['', formModel.ProductName === selectedModel.Name, formModel.ProductName, selectedModel.Name]);
                    return selectedModel && formModel.ProductName === selectedModel.Name ? selectedModel : none;
                };
            }).call(view.Search = {});
            this.Render = function (container) {
                var inputs = {};
                container.append(container = $('<div class="empty_style row">'));
                view.Search.Render(container);


                getSectionWithTitle(container, formModel, 'Quantity', 'Quantity In Pcs', false, inputs);
                getSectionWithTitle(container, formModel, 'Price', 'Price', 'col-md-3 col-sm-6', inputs, true);
                container.append(container = $('<div class="col-md-3 col-sm-6" style="margin-top:36px">'));
                container.append(Global.Click($('<button class="btn btn_cancel btn-success btn-default btn-round" style="width: 100%;" type="button"><span class="glyphicon glyphicon-save"></span> Add</button>'), addItem));
                qntInput = inputs['Quantity'];
                qntInput.keyup(function (e) {
                    if (e.keyCode === 13 || e.which === 13) {
                        addItem();
                    } else {
                        if (formModel.Quantity <= 0) {
                            formModel.Price = 0;
                        } else {
                            formModel.Price = formModel.UnitSalePrice.mlt(formModel.Quantity);
                        }
                    }
                });
            };
        }).call(view.Add = {}, view);
        (function (parent) {
            var view = { Parent: parent };
            function onClickLocation() {

            };
            (function (parent) {
                var view = { Parent: parent }, infowindow, marker, windowModel,
                    formModel = {}, formInputs, map, selectedPoint, drpList = [];
                function onClickLocation() {

                };
                function cancel() {
                    windowModel.Hide(function () { });
                };
                function save() {
                    location = selectedPoint;
                    cancel();
                };
                function show() {
                    windowModel.Show();
                };

                function addLatLng(event) {
                    //console.log(event);
                    selectedPoint = event.latLng.toJSON();
                    //console.log(['selectedPoint', selectedPoint]);
                    infowindow.close();
                    marker.setPosition(event.latLng);
                    marker.setVisible(true);
                };
                function getInfoWindow() {
                    var wnd = $('<div id="infowindow-content">' +
                        '<img src="" width="16" height="16" id="place-icon" />' +
                        '<span id="place-name" class="title"></span><br />' +
                        '<span id="place-address"></span>' +
                        '</div>');
                    return wnd[0];
                };
                function setMapEvents(map, autocomplete) {
                    infowindow = new google.maps.InfoWindow();
                    const infowindowContent = getInfoWindow();
                    infowindow.setContent(infowindowContent);
                    marker = new google.maps.Marker({
                        map: map,
                        anchorPoint: new google.maps.Point(0, -29),
                    });
                    autocomplete.addListener("place_changed", function () {
                        //console.log(['autocomplete', autocomplete]);
                        infowindow.close();
                        marker.setVisible(false);
                        const place = autocomplete.getPlace();

                        if (!place.geometry) {
                            // User entered the name of a Place that was not suggested and
                            // pressed the Enter key, or the Place Details request failed.
                            window.alert("No details available for input: '" + place.name + "'");
                            return;
                        }
                        // If the place has a geometry, then present it on a map.
                        if (place.geometry.viewport) {
                            map.fitBounds(place.geometry.viewport);
                        } else {
                            map.setCenter(place.geometry.location);
                            map.setZoom(17); // Why 17? Because it looks good.
                        }
                        marker.setPosition(place.geometry.location);
                        marker.setVisible(true);
                        selectedPoint = place.geometry.location.toJSON();
                        //console.log(['selectedPoint', selectedPoint]);
                        let address = "";
                        if (place.address_components) {
                            address = [
                                (place.address_components[0] &&
                                    place.address_components[0].short_name) ||
                                "",
                                (place.address_components[1] &&
                                    place.address_components[1].short_name) ||
                                "",
                                (place.address_components[2] &&
                                    place.address_components[2].short_name) ||
                                "",
                            ].join(" ");
                        }
                        infowindowContent.children["place-icon"].src = place.icon;
                        infowindowContent.children["place-name"].textContent = place.name;
                        infowindowContent.children["place-address"].textContent = address;
                        infowindow.open(map, marker);
                    });
                };
                function setMap(container) {
                    var input;
                    container.append(input = $('<input class="form-control" placeholder="Enter a location" style="max-width:250px;">'));
                    input = input[0];
                    map = new google.maps.Map(container, {
                        zoom: 10,
                        // lat=23.751774238435743,  lng=90.37880301475525}]
                        //center: { lat: 23.799014, lng: 90.417781 },
                        center: { lat: 23.751774, lng: 90.37880 },
                        mapTypeId: google.maps.MapTypeId.HYBRID,
                        draggableCursor: 'default',
                        disableDoubleClickZoom: false
                    });
                    const searchBox = new google.maps.places.SearchBox(input);
                    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
                    const autocomplete = new google.maps.places.Autocomplete(input);
                    map.addListener('click', addLatLng);
                    map.addListener("bounds_changed", function () {
                        //console.log(['map.getBounds()', map.getBounds().toJSON()]);
                        searchBox.setBounds(map.getBounds());
                    });
                    setMapEvents(map, autocomplete);
                };
                function dataBound(response) {
                    var list = [];
                    response.Data.Data[0].each(function () {
                        list.push({
                            Name: this[0],
                            Id: this[1],
                            List: this
                        });
                    });
                    response.Data = list;
                };
                function onChange(name, id, drp, fltModel, fltList) {
                    return (function (data) {
                        //console.log(['onChange', data, name, id, drp, fltModel, fltList, fltList.length + 1, drpList]);
                        if (data) {
                            if (fltModel) {
                                fltModel.value = data.Id;
                            }
                            var bound = new google.maps.LatLngBounds({ lat: data.List[4], lng: data.List[3] }, { lat: data.List[5], lng: data.List[2] });
                            //console.log(['bound', bound.toJSON()]);
                            map.fitBounds(bound);
                        } else {
                            if (fltModel) {
                                fltModel.value = -1;
                            }
                        }
                        //
                        for (var i = fltList.length + 1; i < drpList.length; i++) {
                            if (drpList[i].Inputs) {
                                drpList[i].Inputs.val('');
                                drpList[i].Reload && drpList[i].Reload();
                            }
                        }
                        //drp && drp.Reload && drp.Reload();
                    });
                };
                function getDrpModel(name, id, drp, fltModel, fltList) {
                    fltList = fltList || [];
                    return {
                        url: '/AddressArea/' + name + '/AutoComplete',
                        onDataBinding: dataBound,
                        elm: $(formInputs[name + 'Id']).empty(),
                        change: onChange(name, id, drp, fltModel, fltList),
                        page: { "PageNumber": 1, "PageSize": 20, "filter": fltList }
                    }
                };
                function setDrp(formInputs) {
                    var pflt = { field: 'ProvinceId', value: -1, Operation: 0 },
                        dflt = { field: 'DistrictId', value: -1, Operation: 0 },
                        uflt = { field: 'UpazilaId', value: -1, Operation: 0 },
                        union = getDrpModel('Union', none, none, none, [uflt, dflt, pflt]),
                        upazila = getDrpModel('Upazila', 'UpazilaId', union, uflt, [dflt, pflt]),
                        distict = getDrpModel('Distict', 'DistrictId', upazila, dflt, [pflt]),
                        province = getDrpModel('Province', 'ProvinceId', distict, pflt);
                    drpList = [province, distict, upazila, union];
                    Global.AutoComplete.Bind(union);
                    Global.AutoComplete.Bind(upazila);
                    Global.AutoComplete.Bind(distict);
                    Global.AutoComplete.Bind(province);
                };
                function createWindow(template) {
                    windowModel = Global.Window.Bind(template, { width: '90%' });
                    setDrp(formInputs = Global.Form.Bind(formModel, windowModel.View));
                    windowModel.View.find('.btn_cancel').click(cancel);
                    windowModel.View.find('.btn_save').click(save);
                    setMap(windowModel.View.find('.map_container')[0]);
                    show();
                };
                this.Show = function () {
                    selectedPoint = {};
                    if (windowModel) {
                        show();
                    } else {
                        Global.LoadTemplate('/Content/Templates/MapSelector.html', function (response) {
                            createWindow(response);
                        }, function (response) {
                        });
                    }
                };
            }).call(view.Map = {}, view);
            this.Render = function (container) {
                var elm;
                view.Container = container;
                container.append(container = $('<div class="empty_style row">'));
                setCustomerInfo(container);



                container.append(elm = $('<div class="col-md-3 col-sm-6">'));
                elm.append(Global.Click($('<div><label>Set On Map</label></div>' + '<div><button class="btn btn_upload" type="button" style="width: 100%; margin-top:3%;"><span class="glyphicon glyphicon-picture"> </span><span> Set Your Location (Optional) </span></button></div>'), view.Map.Show));
                //getSection(container, formModel, 'Address', 'Your Address');
                view.Container.append(container = $('<div class="empty_style row">'));
                container.append(container = $('<div class="col-md-12 col-sm-12">'));
                container.append('<div><label style="margin: 0px;">Address</label></div>');
                container.append(container = $('<div>'));
                container.append(Global.AutoBind2(formModel, $('<textarea class="form-control" placeholder="Your Address">'), 'Address'));
                return view.Container
            };
        }).call(view.ShippingInfo = {}, view);
        (function () {
            var imgContainer
            function onDelete(model) {
                if (model.IsError) {
                    model.elm.remove();
                    return;
                }
                if (model.IsCompleted) {
                    Global.Controller.Call({
                        url: IqraConfig.Url.Js.WarningController,
                        functionName: 'Show',
                        options: {
                            name: 'Delete',
                            msg: 'Do you want to delete?',
                            save: '/ProductOrderArea/ProductOrder/RemoveFile',
                            data: { Id: model.Id },
                            onsavesuccess: function () {
                                model.elm.remove();
                                var list = [];
                                images.each(function () {
                                    if (this.Id != model.Id) {
                                        list.push(this);
                                    }
                                });
                                images = list;
                            }
                        }
                    });
                } else {
                    model.request.Cancel();
                    model.elm.remove();
                }
                model.IsCompleted = true;
            };
            function save(model) {
                model.request = Global.Uploader.upload({
                    data: model.Data,
                    url: '/ProductOrderArea/ProductOrder/AddFile',
                    onProgress: function (data) {
                        model.Layer.css({ width: parseInt((data.loaded / data.total) * 100) + 'px' });
                    },
                    onComplete: function (response) {
                        model.IsCompleted = true;
                        if (!response.IsError) {
                            model.Layer.remove();
                            model.Id = response.Data;
                            model.IconPath = response.Msg;
                            images.push(model);
                            return;
                        } else if (response.Id == -1) {
                            window.AppComponents && window.AppComponents.LogIn.Render(function () { save(model); }, function () {
                                //console.log('model', model)
                                model.IsError = true;
                                model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                            });
                        } else {
                            model.IsError = true;
                            model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                        }
                    },
                    onError: function (response) {
                        model.IsError = true;
                        model.IsCompleted = true;

                        model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                    }
                });
            }
            function createView(src, file) {
                var layer = $('<div style="position: absolute; z-index: 1; background-color: rgba(20, 20, 20, 0.7); height: 100px; top: 0px; right: -10px; width: 100px;"></div>');
                var btn = $('<div class="btn_delete" style="position: absolute; right: -10px; top: -3px;z-index: 2;"><span class="icon_container" style="border-radius: 50%; padding: 0px 1px; border: 2px solid rgb(255, 255, 255); cursor: pointer; font-size: 0.8em;"> <span class="glyphicon glyphicon-remove"></span></span></div>');
                var img = $('<img style="max-width:100px; max-height:100px;" />'), elm = $('<div class="col-md-3 image_item"></div>').append(btn).append(img).append(layer);
                img.attr('src', src);
                var model = {
                    Id: Global.Guid(),
                    elm: elm,
                    Layer: layer,
                    Data: {
                        Img: { IsFile: true, File: file },
                        Id: '00000000-0000-0000-0000-000000000000',
                        ActivityId: ActivityId
                    }
                };
                Global.Click(btn, onDelete, model);
                imgContainer.append(elm);
                save(model);
            };
            function onChange() {
                var input = this;
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        createView(e.target.result, input.files[0]);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            };
            this.Render = function (container) {
                var elm;
                container.append(container = $('<div class="empty_style row">'));
                container.append(elm = $('<div class="col-md-3">'));
                elm.append(elm = $('<div>'));
                elm.append('<button class="btn btn_upload" type="button" style="width: 100%;"><span class="glyphicon glyphicon-plus"> </span><span> Upload Prescription Here</span></button>');
                elm.append($('<input id="btn_image" class="btn btn_upload btn-white btn-default btn-round" style="position: absolute; left: 0px; top: 0px; opacity: 0; padding: 3px;" type="file">').change(onChange));
                container.append(container = $('<div class="col-md-9">'));
                container.append(imgContainer = $('<div class="img_preview row">'));
                return view.Container
            };
        }).call(view.Upload = {});
        (function () {
            var gridModel, dataSource = [];

            function onRemove(model) {
                var list = [], totalItem = 0, totalQuantity = 0, totalPrice = 0, totalDiscount = 0;

                dataSource.each(function () {
                    if (model.DataId != this.DataId) {
                        list.push(this);
                        totalItem++;
                        totalQuantity += this.Quantity;
                        totalPrice += this.Price;
                        totalDiscount += this.TotalDiscount;
                    }
                });
                dataSource = list;

                formModel.TotalItem = totalItem;
                formModel.TotalQuantity = totalQuantity;
                formModel.TotalPrice = totalPrice;

                formModel.PayablePrice = totalPrice - totalDiscount;
                populate(formModel.PayablePrice);
                $(this).closest('tr').remove();
            };
            function rowBound(elm) {
                //console.log(['rowBound', this, elm, elm.find('.actions')]);
                elm.find('.fa-times');
            };
            this.Add = function (model) {
                //console.log([dataSource]);
                var data, totalItem = 0, totalQuantity = 0, totalPrice = 0, totalDiscount = 0;
                dataSource.each(function () {
                    if (this.Id === model.Id) {
                        data = this;
                    } else {
                        totalItem++;
                        totalQuantity += this.Quantity;
                        totalPrice += this.Price;
                        totalDiscount += this.TotalDiscount;
                    }
                });
                if (data) {
                    data.Quantity = data.Quantity + model.Quantity;
                    data.Price = data.Quantity.mlt(data.UnitSalePrice);
                    data.TotalDiscount = data.Price.mlt(data.Discount).div(100);
                    model = data;
                } else {
                    model.DataId = Global.Guid();
                    model.Actions = 'Delete';
                    model.Price = model.Quantity.mlt(model.UnitSalePrice);
                    model.TotalDiscount = model.Price.mlt(model.Discount).div(100);

                    gridModel.Add(model);
                    dataSource.push(model);
                }

                totalItem++;
                totalQuantity += model.Quantity;
                totalPrice += model.Price;
                totalDiscount += model.TotalDiscount;

                formModel.Name = '';
                formModel.Price = '';
                formModel.Quantity = '';

                formModel.TotalItem = totalItem;
                formModel.TotalQuantity = totalQuantity;
                formModel.TotalPrice = totalPrice;
                formModel.PayablePrice = totalPrice - totalDiscount;
                populate(formModel.PayablePrice);
            };
            this.Render = function (container) {
                dataSource = [];
                container.append(container = $('<div class="grid_container" style="margin: 15px;">'));
                Global.Grid.Bind({
                    elm: container,
                    columns: [
                        { field: 'Name' },
                        { field: 'Quantity' },
                        { field: 'TotalPrice', title: 'Total Price' },
                        { field: 'Actions', className: 'actions', click: onRemove }
                    ],
                    dataSource: [],
                    page: { 'PageNumber': 1, 'PageSize': 1000, showingInfo: ' {0}-{1} of {2} Products' },
                    pagger: false,
                    rowBound: rowBound,
                    onComplete: function (model) {
                        gridModel = model;
                    },
                    Responsive: false
                });
                return view.Container
            };
            this.Get = function () {
                var totalQnt = 0, totalPrice = 0, list = [];
                dataSource.each(function () {
                    totalQnt += this.Quantity;
                    totalPrice += this.Price;
                    list.push({
                        ProductId: this.Id,
                        Quantity: this.Quantity,
                        UnitPrice: this.UnitSalePrice,
                        TotalAmount: this.Price,
                        PayableAmount: this.Price - this.TotalDiscount,
                        Discount: this.Discount,
                        DiscountTotal: this.TotalDiscount
                    });
                });
                return { List: list, TotalQnt: totalQnt, TotalPrice: totalPrice };
            };
        }).call(view.Grid = {});
        this.Render = function (container) {
            var elm;
            images = [];
            location = {};
            view.Container = container.empty();
            AppBase.State.Set({
                Param: [container],
                Component: parent.UrgentOrder,
            }, 'OrderUsPage', '/OrderUs');

            resetMenu(1);
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Order Us', view.Parent.Home.Render, view.Parent.Home.Container);

            setExternalLink(container);
            container.append(container = $('<div class="request_product">'));
            setNotice(container);
            view.Add.Render(container);
            view.Grid.Render(container);
            setTotalInfo(container);
            view.ShippingInfo.Render(container);
            view.Upload.Render(container);

            container.append(elm = $('<div class="empty_style row">'));
            elm.append(elm = $('<div class="col-md-12 col-sm-12">'));
            elm.append('<div><label>Remarks</label></div>');
            elm.append($('<div>').append(Global.AutoBind2(formModel, $('<textarea class="form-control" placeholder="Description (Optional)">'), 'Remarks')));

            view.Payment.Render(container, formModel);

            setFooterNotice(container);
            setIsAggreed(container);
            container.append(container = $('<div class="text-center formFooter FooterFormMenu">'));
            container.append(Global.Click($('<button class="btn btn-success btn-default btn-round" type="button" style="margin-bottom:15px"><span class="glyphicon glyphicon-upload"></span> Send </button>'), save));
            nameInput.focus();
            populate();
            return view.Container
        };
    }).call(view.UrgentOrder = {}, view);

    (function (parent) {
        var view = { Parent: parent }, gridModel, dataSource, markerList = [],
            infoList = [], infowindow, infowindowContent, markerDic = {};
        function getData(func) {
            if (dataSource) {
                func(dataSource);
            } else {
                Global.CallServer('/FindStoreArea/FindStore/MapData', function (response) {
                    if (!response.IsError) {
                        //console.log(['response', response]);
                        dataSource = response.Data.Data[0];
                        func(dataSource);
                    }
                }, function () {

                }, {}, 'GET');

            }
        };
        function setData(data) {
            //console.log(['data', data]);
            markerList = [];
            infoList = [];
            data.each(function () {
                var marker = new google.maps.Marker({
                    map: map,
                    anchorPoint: new google.maps.Point(0, -29),
                    icon: {
                        url: '/Content/assets/iqraimages/MapIcon/mapicon-40x40-new2.png',
                        //size: {width:27,height:43}
                    }
                });
                marker.setPosition({ lat: this[1], lng: this[2] });
                marker.setVisible(true);
                markerList.push(marker);
                markerDic[this[0]] = marker;
            });
            //console.log(['markerList', markerList]);
        };
        function onBranchClick(data) {

            //infowindowContent.children["place-icon"].src = '';
            infowindowContent.children["place-name"].textContent = data.Name + ' Branch';
            infowindowContent.children["place-address"].textContent = data.Location;
            infowindowContent.children["place-phone"].textContent = 'Mobile : ' + data.Mobile;
            infowindow.open(map, markerDic[data.Id]);
            map.setCenter({ lat: data.Lat, lng: data.Lng });
            map.setZoom(17); // Why 17? Because it looks good.
        };

        function getInfoWindow() {
            var wnd = $('<div id="infowindow-content">' +
                '<img src="/Content/assets/iqraimages/LPlogo.jpg" width="16" height="16" id="place-icon" />' +
                '<span id="place-name" class="title"></span><br />' +
                '<span id="place-address"></span><br />' +
                '<span id="place-phone"></span>' +
                '</div>');
            return wnd[0];
        };
        function setMap() {

            var input;
            view.MapContainer.append(input = $('<input class="form-control" style="max-width:250px;">'));
            input = input[0];
            map = new google.maps.Map(view.MapContainer, {
                zoom: 14,
                center: { lat: 23.7516891, lng: 90.3792672 },
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                draggableCursor: 'default',
                disableDoubleClickZoom: false
            });
            infowindow = new google.maps.InfoWindow();
            infowindowContent = getInfoWindow();
            infowindow.setContent(infowindowContent);
            getData(setData);
        };
        this.SetMap = function () {
            if (view.MapContainer) {
                setMap();
            }
        };
        this.Render = function (container) {
            view.Container = container.empty();
            resetMenu(2);
            var gridContainer;

            AppBase.State.Set({
                Param: [container],
                Component: parent.FindStore,
            }, 'FindStorePage', '/FindStore');

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Branch Location', view.Parent.Home.Render, view.Parent.Home.Container);

            container.append(container = $('<div class="request_product">'));
            container.append(gridContainer = $('<div class="grid_container" style="margin: 2%;">'));
            Global.Grid.Bind({
                elm: gridContainer,
                columns: [
                    { field: 'Name', Width: 30, title: 'Branch Name', filter: { Operation: 5 }, Operation: 5, click: onBranchClick },
                    { field: 'Mobile', Width: 20, filter: { Operation: 5 }, Operation: 5 },
                    { field: 'Location', Width: 30, filter: { Operation: 5 }, Operation: 5, className: 'hide_on_mobile'}
                ],
                url: '/FindStoreArea/FindStore/Get',
                //dataSource: [],
                page: { 'PageNumber': 1, 'PageSize': 3, SortBy: 'Position', showinginfo: ' {0}-{1} of {2} Branches' },
                onComplete: function (model) {
                    gridModel = model;
                },
                Responsive: false
            });
            container.append(container = $('<div class="map_container" style="margin: 2%; height:500px;">'));
            view.MapContainer = container[0];
            //console.log(['window.google', window.google]);
            if (window.google) {
                setMap();
            }
            return view.Container
        };
    }).call(view.FindStore = {}, view);

    (function (parent) {
        var view = { Parent: parent };
        this.Render = function (container) {
            view.Container = container.empty();
            AppBase.State.Set({
                Param: [container],
                Component: parent.HowToOrder,
            }, 'HowToOrderPage', '/HowToOrder');

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'How To Order', view.Parent.Home.Render, view.Parent.Home.Container);

            container.append(container = $('<div class="request_product">'));
            container.append(container = $('<div class="row">'));
            container.append(elm = $('<div class="col-md-6">'));
            elm.append($('<div class="center_order_text">' +
                '<h2>To buy Product or Medicine follow the steps:</h2>' +
                '<p>1. Search product from search option</p>' +
                '<p>2. Press Add to cart</p>' +
                '<p>3. Check out the after all product added to chart</p>' +
                '<p>4. Provide delivery address, picture of prescription and payment info</p>' +
                '<p>5. After order submit you will get order number from Email and SMS</p>' +
                '<p>6. LP agent will call you to confirm your order</p>' +
                '<p>7. LP will deliver your ordered product</p>' +
                '</div>'));
            container.append(elm = $('<div class="col-md-6">'));
            elm.append($('<div class="container_vid">' +
                '<iframe class="responsive_iframe"  width="560" height="315" src="https://www.youtube.com/embed/jDU08QWWWh8" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>' +
                '</div>'));
            return view.Container
        };
    }).call(view.HowToOrder = {}, view);

    (function (parent, viewModel) {
        var view = { Parent: parent }, that = this;
        function creator(parent) {
            var view = { Parent: parent, parentViewModel: viewModel }, loader = {}, formModel = {}, elm,
                filterModel = { "field": "ParentId", "value": '', Operation: 0 },
                page = { "PageNumber": 1, "PageSize": 5, filter: [filterModel] };

            function getElm(model, title, field, cls, viewModel) {
                cls = cls + (model.IsLiked == title ? ' active' : '');
                var elm = $('<a class="' + cls + '"> ' + title + ' ' + (model[field] > 0 ? '(<span class="active no_margin">' + model[field] + '</span>)' : '') + '</a>');
                return elm;
            };
            function fillCommentSection(container, data, viewModel) {
                container.append('<a class="comment_time col"><em>' + data.CreatedAt.getDate().format('dd, mmm-yyyy') + '</em></a>');
                container.append(Global.Click(getElm(data, 'Like', 'LikeCount', 'btn_like', viewModel), setLike, data, false, viewModel));
                container.append(Global.Click(getElm(data, 'Unlike', 'UnLikeCount', 'btn_unlike', viewModel), setUnlike, data, false, viewModel));
                container.append(Global.Click(getElm(data, 'Reply', 'ReplyCount', 'btn_reply', viewModel), onComment, data, false, viewModel));
            };

            function setLike(model, viewModel) {
                var postModel = { 'Value': 'Like', ActivityId: ActivityId, CommentId: model.Id };
                Global.CallServer('/ReviewArea/Liker/Create', function (response) {
                    if (!response.IsError) {
                        if (model.IsLiked == 'Unlike') {
                            model.UnLikeCount--;
                        }
                        if (model.IsLiked != 'Like') {
                            model.LikeCount++;
                        }
                        model.IsLiked = 'Like';
                        fillCommentSection(viewModel.EventContainer.empty(), model, viewModel);
                    } else {
                        if (response.Id == -1) {
                            window.AppComponents && window.AppComponents.LogIn.Render(function () { setLike(model, viewModel) });
                        } else {
                            alert(response.Msg || 'Errors');
                        }
                    }
                }, function (response) {
                    response.Id = -8;
                    alert(response.Msg || 'Errors');
                }, postModel, 'POST');
            };
            function setUnlike(model, viewModel) {
                var postModel = { 'Value': 'Unlike', ActivityId: ActivityId, CommentId: model.Id };
                Global.CallServer('/ReviewArea/Liker/Create', function (response) {
                    if (!response.IsError) {
                        if (model.IsLiked == 'Like') {
                            model.LikeCount--;
                        }
                        if (model.IsLiked != 'Unlike') {
                            model.UnLikeCount++;
                        }
                        model.IsLiked = 'Unlike';
                        fillCommentSection(viewModel.EventContainer.empty(), model, viewModel);
                    } else {
                        if (response.Id == -1) {
                            window.AppComponents && window.AppComponents.LogIn.Render(function () { setLike(model, viewModel) });
                        } else {
                            alert(response.Msg || 'Errors');
                        }
                    }
                }, function (response) {
                    response.Id = -8;
                    alert(response.Msg || 'Errors');
                }, postModel, 'POST');
            };
            function onComment(model, viewModel) {
                if (model.ReplySetted) {

                } else {
                    model.ReplySetted = {};
                    creator.call(model.ReplySetted, view, viewModel)(viewModel.ReplyContainer, model);
                }
            };
            function saveReview(model, viewModel) {
                //console.log(['model', model]);
                if (formModel.Text) {
                    var postModel = { 'Content': formModel.Text, ActivityId: ActivityId };
                    if (model) {
                        postModel.ParentId = model.Id
                    }
                    Global.CallServer('/ReviewArea/AppReview/Create', function (response) {
                        if (!response.IsError) {
                            loader.Add(response.Data);
                            model.ReplyCount++;
                            fillCommentSection(viewModel.EventContainer.empty(), model, viewModel);
                            formModel.Text = '';
                        } else {
                            if (response.Id == -1) {
                                window.AppComponents && window.AppComponents.LogIn.Render(function () { saveReview(model, viewModel) });
                            } else {
                                alert(response.Msg || 'Errors');
                            }
                        }
                    }, function (response) {
                        response.Id = -8;
                        alert(response.Msg || 'Errors');
                    }, postModel, 'POST');
                }
            };
            (function () {
                var commentContainer, moreContainer;
                function setLoadMore(container) {
                    if (!moreContainer) {
                        container.append(container = moreContainer = $('<div class="load_more_container">'));
                    }
                    moreContainer.empty();
                    moreContainer.append(Global.Click($('<a class="load_more">Load More</a>'), function () {
                        page.PageNumber++;
                        load(commentContainer);
                    }));
                };
                function setCommnetEvent(container, data, viewModel) {
                    viewModel.ReplyContainer = $('<div class="comment_reply_container">');
                    container.append(viewModel.EventContainer = container = $('<div class="comment_event">')).append(viewModel.ReplyContainer);
                    fillCommentSection(container, data, viewModel);
                };
                function createLeft(container, data, viewModel) {
                    container.append(container = $('<div class="col ctr_img">'));
                    container.append(container = $('<div class="img_container">'));
                    container.append('<div class="img_round"><img src="/Content/assets/iqraimages/Icon/profile-user.png" /></div>');
                };
                function createDetails(container, data, viewModel) {
                    container.append(container = $('<div class="commnet-dettail">'));
                    container.append('<div><a><strong>' + data.Customer + '</strong></a><div>');
                    container.append('<div class="commnet-content">' + data.Content + '</div>');
                    return container;
                    //container.append('<div class="info-author"><em>' + data.CreatedAt.getDate().format('dd/MM/yyyy') + '</em></div>');
                };
                function create(container, data, viewModel) {
                    container.append(container = $('<div class="item">'));
                    container.append(container = $('<div class="row">'));
                    createLeft(container, data, viewModel);
                    container.append(container = $('<div class="col commnet-dettail_container">'));
                    createDetails(container, data, viewModel);
                    setCommnetEvent(container, data, viewModel);
                };
                function load(container) {
                    moreContainer.html('<img src="/Content/IqraService/Img/loading_line.gif" />');
                    Global.CallServer('/ReviewArea/AppReview/Get', function (response) {
                        if (!response.IsError) {
                            response.Data.Data.each(function () {
                                create(container, this, {});
                            });
                            if (response.Data.Data.length < 5) {
                                moreContainer.empty();
                            } else {
                                setLoadMore(moreContainer);
                            }
                        } else {

                        }
                    }, function (response) {
                        response.Id = -8;
                    }, page, 'POST');
                };
                this.Load = function (container, model) {
                    filterModel.value = model ? model.Id : '00000000-0000-0000-0000-000000000000';
                    //console.log(['filterModel', page, filterModel]);
                    container.append(commentContainer = $('<div class="comment_container">'));
                    setLoadMore(container);
                    container = commentContainer;
                    load(container);
                };
                this.Add = function (model) {
                    create(commentContainer, model)
                };
            }).call(loader);

            this.Render = function (container, model) {
                page = { "PageNumber": 1, "PageSize": 5, filter: [filterModel] };
                view.Container = container.empty();
                container.append(container = $('<div class="product-comments-block-tab" style="max-width:800px; margin:0 auto;">'));
                container.append(elm = $('<div class="new_comment_container" style="margin-bottom: 15px;">'));
                container.append('<p> </p>');
                loader.Load(container, model);
                elm.append(elm = $('<div class="row">'));
                container = elm;
                container.append(elm = $('<div class="col-md-8">').append('<input data-binding="Text" class="input form-control" placeholder="Post Your Review Here" type="text">'));
                formModel.Text = "";
                $(Global.Form.Bind(formModel, elm)['Text']).focus();
                container.append(elm = $('<div class="col-md-4">'));
                elm.append(Global.Click($('<button class="button form-control" type="submit" style="padding: 0px !important"> Post</button>'), saveReview, model));

                return view.Container
            };
            return this.Render;
        }
        this.Render = function (container) {
            view.Container = container.empty();
            resetMenu(3);

            AppBase.State.Set({
                Param: [view.Container],
                Component: parent.Comments,
            }, 'CommentsPage', '/Comments');

            //console.log(['CommentsPage', container, parent.Comments]);

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Review', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="">'));
            creator.call({}, parent)(container);
            return container;
        };
    }).call(view.Comments = {}, view);

    (function (parent) {
        var view = { Parent: parent };

        function save(model) {
            model.request = Global.Uploader.upload({
                data: model.Data,
                url: '/CareerArea/Career/AddFile',
                onProgress: function (data) {
                    //model.Layer.css({ width: parseInt((data.loaded / data.total) * 100) + 'px' });
                },
                onComplete: function (response) {
                    model.IsCompleted = true;
                    if (!response.IsError) {
                        model.Id = response.Data;
                        alert('Uploaded Successful');
                        return;
                    } else {
                        model.IsError = true;
                        alert('Denied !! Please Upload Again');
                        //model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                    }
                },
                onError: function (response) {
                    model.IsError = true;
                    model.IsCompleted = true;

                    //model.Layer.css({ width: '100px' }).html('<div style="color: red; font-weight: bold; margin: 0px auto; padding: 38px 0px 38px 15px;">Error </div>');
                }
            });
        }
        function commonLeft(elm) {
            var container, input;
            elm.append(elm = $('<div class="col-md-6">'));
            elm.append('<h1> Are you Dedicated, Hardworking and Fun? Join Us!</h1><p class="career_common">We believe in those people who are passionate about their work and feel the joy of working. We are always welcome and eagerly waiting for you.</p>');
            elm.append(container = $('<div style="position: relative;">'));
            container.append('<button class="btn btn_upload" type="button" style="width: 100%;"> <span class="glyphicon glyphicon-plus"></span> <span> Drop Your CV Here</span></button>');
            container.append(input = $('<input id="btn_image" class="btn btn_upload btn-default btn-round" style="position: absolute; left: 0px; top: 0px; opacity: 0; padding: 3px; width: 100%;" type="file">'));
            input.change(function () {
                var input = this;
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var model = {
                            Data: {
                                Img: { IsFile: true, File: input.files[0] },
                                Id: '00000000-0000-0000-0000-000000000000',
                                ActivityId: ActivityId
                            }
                        };
                        save(model);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            });
        };
        function commonRight(elm) {
            elm.append(elm = $('<div class="col-md-6">'));
            elm.append('<img src="/Content/assets/iqraimages/Career/Lazz_Emp.jpg" alt="LazzEmployee" />');
        };

        function CurrentJob(elm, data) {

            var container, input;

            elm.append(elm = $('<div class="timeline col-md-12">'));
            elm.append(elm = $('<div class="timeline-panel">'));
            elm.append(elm = $('<div class="timeline-body">'));
            elm.append($('<h2 class="job_title">' + data.Name + '</h2>'));
            elm.append($('<div class="job_nat"><h4> No. of Vacancies</h4><p>' + data.Vacancy + '</p></div>)'));
            //elm.append($('<div class="job_nat"><h4> Job Context </h4><p>' + data.JobContext + '</p></div>)'));
            elm.append($('<div class="job_nat"><h4> Employment Status </h4><p>' + data.EmploymentStatus + '</p></div>)'));
            elm.append($('<div class="job_nat"><h4> Educational Requirement </h4><p>' + data.EducationalRequirement + '</p></div>)'));
            elm.append($('<div class="job_nat"><h4> Job Location </h4><p>' + data.JobLocation + '</p></div>)'));
            elm.append($('<div class="job_nat"><h4> Salary </h4><p>' + data.Salary + '</p></div>)'));
            elm.append($('<div class="timeline-footer">'));
            elm.append(container = $('<div style="position: relative;">'));
            container.append('<button class="btn btn_upload" type="button" style="width: 35%;"> <span class="glyphicon glyphicon-plus"></span> <span> Drop Your CV Here</span></button>');
            container.append(input = $('<input id="btn_image" class="btn btn_upload btn-default btn-round" style="position: absolute; left: 33%; top: 0px; opacity: 0; padding: 3px; width: 35%;" type="file">'));
            input.change(function () {
                var input = this;
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        var model = {
                            Data: {
                                Img: { IsFile: true, File: input.files[0] },
                                Id: data.Id,
                                ActivityId: ActivityId
                            }
                        };
                        //console.log("[model]", model);
                        save(model);
                    }
                    reader.readAsDataURL(input.files[0]);
                }
            });
        };
        function load(container) {
            Global.CallServer('/CareerArea/Career/JobCircular', function (response) {
                if (!response.IsError) {
                    var item;
                    response.Data.each(function () {
                        item = {
                            "Id": this[0],
                            "Name": this[1],
                            "Vacancy": this[2],
                            "JobResponsibility": this[3],
                            "EmploymentStatus": this[4],
                            "EducationalRequirement": this[5],
                            "JobLocation": this[6],
                            "Salary": this[7],
                            "IsDeleted": this[9]
                        };
                        if (item.IsDeleted != true) {
                            CurrentJob(container, item);
                        }

                    });
                } else {

                }
            }, function (response) {
                response.Id = -8;
            }, {}, 'GET');
        };
        this.Render = function (container) {
            view.Container = container.empty();
            resetMenu(4);

            AppBase.State.Set({
                Param: [container],
                Component: parent.Career,
            }, 'CareerPage', '/Home/Career');

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Career', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="container section">'));
            container.append(elm = $('<div class="row">'));
            commonLeft(elm);
            commonRight(elm);

            container.append($('<div class="page-header text-center"><h1 id="timeline">Current Opportunities</h1></div>'));
            container.append(elm = $('<div class="row">'));
            //CurrentJob(elm);
            //jobRight(elm);
            load(elm);

            return view.Container
        };
    }).call(view.Career = {}, view);

    (function (parent) {
        var view = { Parent: parent };
        function LoadCategory(elm, data) {

            var container, input;
            //elm.append('<button class="btn btn-default filter-button" data-filter="all">' + data.Name + '</button>');
            //elm.append('<br />');
            elm.append(elm = $('<div class="gallery_product col-lg-4 col-md-4 col-sm-4 col-xs-6 filter hdpe">'));
            elm.append('<img src="/Content/ImageData/Gallery/Orginal/' + data.ImageName + '" class="img-responsive gallery_image">');

        };
        function load(container) {
            Global.CallServer('/GalleryArea/Gallery/GetGallery', function (response) {
                if (!response.IsError) {
                    var item;
                    response.Data.each(function () {
                        item = {
                            "Id": this[0],
                            "Name": this[1],
                            "Image": this[2],
                            "IsDeleted": this[7],
                            "ImageName": this[8],
                        };
                        if (item.IsDeleted != true) {
                            LoadCategory(container, item);
                        }
                        //LoadCategory(container, item);
                    });
                } else {

                }
            }, function (response) {
                response.Id = -8;
            }, {}, 'GET');
        };
        this.Render = function (container) {
            view.Container = container.empty();
            resetMenu(5);

            AppBase.State.Set({
                Param: [container],
                Component: parent.Gallery,
            }, 'GalleryPage', '/Home/Gallery');

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Gallery', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="container section">'));
            container.append(container = $('<div class="row">'));
            container.append(elm = $('<div align="center">'));
            load(elm);
            return view.Container
        };
    }).call(view.Gallery = {}, view);

    (function (parent) {
        var view = { Parent: parent };

        function directorVoiceLeft(container) {

            container.append(container = $('<div class="col-xl-3 col-lg-6 col-md-6 col-sm-6 col-12">'));
            container.append(elm = $('<div class="my-card">'));
            elm.append($('<img class="my-card-img" src="/Content/assets/iqraimages/Directors/Chairman-600x400-f.jpg" />' +
                '<div class="my-card-body trainer-card-body">' + '<center>' + '<h5>Syeda Mahfuza Rahman </h5>' + '</center>' +
                '<h6>CHAIRMAN</h6>' + '<div>' + '<p>' + 'Teaching was her first career, and Syeda Mahfuza Rahman brings the values of integrity, ethics and sincerity to Lazz Pharma. She has always prioritized customer satisfaction over all else, and her contribution behind the success of this organization is immense. Being the chairman of this family-owned business, Syeda sees the company’s employees as her extended family, and wants every single customer to have the best experience possible when shopping with Lazz Pharma.' +
                '</p>' + '</div>' +
                '</div>'));
        };
        function directorVoiceRight(container) {

            container.append(container = $('<div class="col-xl-3 col-lg-6 col-md-6 col-sm-6 col-12">'));
            container.append(elm = $('<div class="my-card">'));
            elm.append($('<img class="my-card-img" src="/Content/assets/iqraimages/Directors/lutfor-rahman-580x400-f.jpg" />' +
                '<div class="my-card-body trainer-card-body">' + '<center>' + '<h5>Md. Lutfor Rahman</h5>' + '</center>' +
                '<h6>MANAGING DIRECTOR</h6>' + '<div>' +
                '<p>' +
                'As a young entrepreneur in the 70s, he always had the dream to go beyond the typical concept of a Pharmacy in Bangladesh. Ever since the journey began, Lazz Pharma stood out, as its first and foremost focus was honesty and customer satisfaction. Over the last 40+ years, Lazz Pharma Ltd has never compromised with this core value of its business strategy. As the founder of this organization, Mr Lutfor Rahman wishes to keep serving the country with honesty and sincerity. '
                + '</p>' + '</div>' +
                '</div>'));
        };
        function directorVoiceLowerLeft(container) {

            container.append(container = $('<div class="col-xl-3 col-lg-6 col-md-6 col-sm-6 col-12">'));
            container.append(elm = $('<div class="my-card">'));
            elm.append($('<img class="my-card-img" src="/Content/assets/iqraimages/Directors/photo-1-f.jpg" />' +
                '<div class="my-card-body trainer-card-body">' + '<center>' + '<h5>Shakib Rahman</h5>' + '</center>' +
                '<h6>Director, Business Operation</h6>' + '<div>' + '<p>' + 'Shakib Rahman joined Lazz Pharma Ltd in August 1998. With his experience of almost 20 years, the young entrepreneur now oversees the administration of the entire business, including the accounting department, financial reporting and franchise management. Shakib Rahman believes in constant improvement in customer service and satisfaction, and his accumulated experience in managing the highly skilled workforce of the company makes him integral to the company’s success.' +
                '</p>' + '</div>' +
                '</div>'));
        };
        function directorVoicelowerRight(container) {

            container.append(container = $('<div class="col-xl-3 col-lg-6 col-md-6 col-sm-6 col-12">'));
            container.append(elm = $('<div class="my-card">'));
            elm.append($('<img class="my-card-img" src="/Content/assets/iqraimages/Directors/photo 2 - final-f.jpg" />' +
                '<div class="my-card-body trainer-card-body">' + '<center>' + '<h5>Sumona Rahman</h5>' + '</center>' +
                '<h6>Director, Admin & Business Strategy</h6>' + '<div>' + '<p>' + 'Sumona comes on board with more than 20 years of overseas experience in corporate administration, and is primarily focused on e-commerce and R&D for the core services of the company. Her primary goal with the e-commerce facet of Lazz Pharma is to make sure the customer experience is efficient and timely. Being a specialist in human resources management, Sumona oversees the technical infrastructure and systems integration across all of Lazz Pharma, and wishes to move the business forward globally.' +
                '</p>' + '</div>' +
                '</div>'));
        };

        function setCorporateContent(container, imgUrl) {
            container.append(container = $('<div class="col-xl-3 col-lg-3 col-md-3 col-sm-3 col-12">'));
            container.append(elm = $('<div class="my-card">'));
            elm.append($('<img class="my-card-img" src="' + imgUrl + '" />'));
        };

        function setCorporateIncharge(container) {
            container.append(elm = $('<div class="team_heading_title text-center">' +
                '<h1 class="text-uppercase">Corporate Associates</h1>' +
                '<hr />' +
                '</div>'));
            container.append(container = $('<div class="container mt-5 d-flex justify-content-center">'));
            container.append(container = $('<div class="row">'));
            AppService.Img.CorporateMembers.each(function () {
                setCorporateContent(container, this);
            });
        };

        this.Render = function (container) {
            view.Container = container.empty();
            resetMenu(6);

            AppBase.State.Set({
                Param: [container],
                Component: parent.AboutUs,
            }, 'AboutUsPage', '/Home/AboutUs');

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'About Us', view.Parent.Home.Render, view.Parent.Home.Container);

            container.append(container = $('<div class="container">'));
            container.append(container = $('<div class="row">'));
            container.append(container = $('<div class="col-md-12">'));
            container.append(elm = $('<div id="myCarousel" class="carousel slide" data-ride="carousel">'));
            elm.append($('<ol class="carousel-indicators">' +
                '<li data-target="#myCarousel" data-slide-to="0" class="active"></li>' +
                '<li data-target="#myCarousel" data-slide-to="1" ></li>' +
                '<li data-target="#myCarousel" data-slide-to="2" ></li>' +
                '<li data-target="#myCarousel" data-slide-to="3" ></li>' +
                '</ol>'));
            elm.append(elm = $('<div class="carousel-inner">'));
            elm.append($('<div class="item active">' +
                '<img src="/Content/assets/iqraimages/AboutSlider/About 4-f.jpg" alt="Lazz Pharma" style="width:100%;">' +
                '</div>' + '<div class="item">' +
                '<img src="/Content/assets/iqraimages/AboutSlider/About 3-f.jpg" alt="Lazz Pharma" style="width:100%;">' +
                '</div>' + '<div class="item">' +
                '<img src="/Content/assets/iqraimages/AboutSlider/About 2-f.jpg" alt="Lazz Pharma" style="width:100%;">' +
                '</div>' + '<div class="item">' +
                '<img src="/Content/assets/iqraimages/AboutSlider/About 1-f.jpg" alt="Lazz Pharma" style="width:100%;">' +
                '</div>'));
            elm.append($('<a class="left carousel-control"  href="#myCarousel" data-slide="prev">' +
                '<span class="glyphicon glyphicon-chevron-left"></span>' +
                '<span class="sr-only"> Previous </span>' +
                '</a>'));
            elm.append($('<a class="right carousel-control"  href="#myCarousel" data-slide="next">' +
                '<span class="glyphicon glyphicon-chevron-right"></span>' +
                '<span class="sr-only"> Next </span>' +
                '</a>'));
            container.append(elm = $('<div class="team_heading_title text-center">' +
                '<h1 class="text-uppercase">Board of Directors</h1>' +
                '<hr />' +
                '</div>'));
            container.append(container = $('<div class="container mt-5 d-flex justify-content-center">'));
            container.append(container = $('<div class="row">'));
            directorVoiceLeft(container);
            directorVoiceRight(container);

            container.append(container = $('<div class="row">'));
            directorVoiceLowerLeft(container);
            directorVoicelowerRight(container);

            setCorporateIncharge(container);

            return view.Container
        };
    }).call(view.AboutUs = {}, view);

    (function (parent) {
        var view = { Parent: parent }, isActive, resultContainer, availability = '',
            page = { 'PageNumber': 1, 'PageSize': 10 };
        function productGrid(container) {
            container.append(container = $('<div id="view-product-list" class="view-product-list">'));
            container.append($('<h2 class="page-heading"><span class="page-heading-title">Search Results</span></h2>'));
            //container.append($('<ul class="display-product-option">' +
            //    '<li class="view-as-grid selected"><span>grid</span></li>' +
            //    '<li class="view-as-list"><span>list</span></li>' +
            //    + '</ul>'));
            container.append(resultContainer = container = $('<ul class="row product-list grid">'));

            return container;
        };
        function create(container, data) {
            var elm;
            var oldPrice = '', price = data.UnitSalePrice;
            if (data.Discount > 0) {
                price = data.UnitSalePrice - data.UnitSalePrice.mlt(data.Discount).div(100);
                oldPrice = '<del style="color:red; font-weight: normal;">৳ ' + Math.round(data.UnitSalePrice) + '</del>';
            }
            container.append(container = $('<li class="col-xs-6 col-sm-2 col-md-2">'));
            container.append(container = $('<div class="product-container">'));
            container.append(elm = $('<div class="left-block">' +
                '<a><img class="search_product_image" src="' + AppBase.GetImagePath(data, 'Small', '/Content/assets/images/med.jpg') + '" /></a>' +
                + '</div>'));


            //elm.append(AppBase.Click($('<div class="add-to-cart"><a title="Add to Cart">Add to Cart</a></div>'), function (evnt, container, data) {
            //    var elm = container.closest('.product-container');
            //    AppBase.CartBox.Add(data, elm, evnt);
            //    //AppBase.CartBox
            //}, container, data));

            

            container.append($('<div class="right-block">' +
                ' <h3 class="product-name" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;"><a href="/ProductArea/Product/Details?Id=' + data.Id + '">' + data.Name + '<span> ' + data.Strength + '</span>' + '</a></h3><span>' +
                '<div class="product_des">' + data.Suplier + '</div>' +
                '<div class="product_gen">' + data.GenericName + '</span></div>' +
                '<div class="unit_text"><span> Type - ' + data.Category + '</span></div>' +
                '<div class="content_price"><span class="price product-price">৳ ' + price.toFloat(1) + '</span><span class="price old-price">' + oldPrice + '</span></div>' +
                +'</div>'));

            //if (data.TotalStock > 0) {
                container.append(AppBase.Click($('<div style="text-align: center"><div style="margin-top: 2%;"><a class="btn_add_to_cart" title="Add to Cart">Add to Cart</a></div></div>'), function (evnt, container, data) {
                    var elm = container.closest('.product-container');
                    AppBase.CartBox.Add(data, elm, evnt);
                    //AppBase.CartBox
                }, container, data));
            //}
            //else {
            //    container.append('<div style="text-align: center"><div style="margin-top: 2%;"><span style="background-color: #e33030;" class="btn_add_to_cart"> Out of Stock </span></div></div>');
            //}
        };
        function showData(container, list) {
            var item;
            list.each(function () {
                item = {
                    "Id": this[0],
                    "Name": this[1],
                    "GenericName": this[2],
                    "Strength": this[3],
                    "UnitSalePrice": this[4],
                    "Discount": this[5],
                    "ImagePath": this[6],
                    "ImageType": this[7],
                    "Category": this[8],
                    "Suplier": this[9],
                    "TotalStock": this[10],
                };

                create(container, item);
            });
        };
        function setWaiting(container) {
            var elm;
            container.append(container = $('<li class="col-sx-12 col-sm-4 col-md-3">'));
            container.append(elm = $('<div class="product-container">'));
            elm.append(elm = $('<img class="search_product_image" src="/Content/IqraService/Img/Spin-1s-80px.gif" />'));
            return container;
        };
        function onLoad(page, func) {
            Global.CallServer('/ProductArea/Product/Searches', function (response) {
                if (!response.IsError) {
                    func(response.Data);
                } else {

                }
            }, function (response) {
                response.Id = -8;
            }, page, 'POST');

        };
        (function () {

            function onScroll() {
                if (isActive && !view.AllLoaded && !view.IsLoading && ($(document.body).height() - window.innerHeight - window.scrollY - $('#footer').height() < 350)) {
                    //console.log(['onScroll', $(document.body).height(), window.scrollMaxY, window.innerHeight, window.scrollY, window.scrollMaxY - window.innerHeight - window.scrollY]);
                    if (view.SearchEvent) {
                        clearTimeout(view.SearchEvent);
                    }
                    view.SearchEvent = setTimeout(function () {
                        page.PageNumber++;
                        view.IsLoading = true;
                        var waiting = setWaiting(resultContainer);
                        onLoad(page, function (data) {
                            waiting.remove();
                            view.IsLoading = false;
                            //console.log(['AllLoaded', view.AllLoaded, data.length, page.PageSize]);
                            view.AllLoaded = data.length < page.PageSize;
                            showData(resultContainer, data);
                        });
                    }, 150);
                }
            };
            $(document).scroll(function (e) {
                onScroll();
            });
            document.body.onwheel = function (e) {
                onScroll();
            };
        })();
        this.Render = function (container, filter, txt) {
            view.Container = container.empty();
            resetMenu(false);
            
            view.AllLoaded = true;
            AppHeader.Component.IsSearchPage = true;
            AppBase.State.Set({
                Param: [container],
                Component: parent.Search,
                OnClose: function () {
                    isActive = false;
                    AppHeader.Component.IsSearchPage = false;
                    AppHeader.Component.SearchProduct = none;
                }
            }, 'Search', '/Search');

            isActive = true;
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Search', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="result_container row">'));
            container = productGrid(container);
            AppHeader.Component.SearchProduct = function (filter, text) {
                var query;
                if (text) {
                    query = [];
                    text.split(' ').each(function () {
                        text = (this + '').trim();
                        if (text && text.length > 0) {
                            query.push(text);
                        }
                    });
                    if (query.length == 0) {
                        query = none;
                    }
                }
                var waiting = setWaiting(container);
                onLoad(page = { 'PageNumber': 1, 'PageSize': 20, Query: query }, function (data) {
                    view.AllLoaded = false;
                    container.empty();
                    showData(container, data);
                });
            };
            AppHeader.Component.SearchProduct(filter || [], txt || '');
            return view.Container
        };
    }).call(view.Search = {}, view);

    (function (parent) {
        var view = { Parent: parent };
        function PrintElem(elem) {
            var mywindow = window.open('', 'PRINT', 'height=400,width=600');
            mywindow.document.write(document.getElementById(elem).innerHTML);
            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10*/
            mywindow.print();
            mywindow.close();
            return true;
        }

        function GetImage(data) {
            var c = document.createElement("Canvas");
            var img = document.getElementById("lazz");

            c.width = 600;
            c.height = 600;
            var ctx = c.getContext("2d");

            ctx.strokeStyle = "black";
            ctx.strokeRect(5, 5, 500, 550);
            ctx.fillStyle = "white";
            ctx.fillRect(5, 5, 500, 550);
            ctx.font = "20px sans-serif";
            ctx.fillStyle = "red";
            ctx.drawImage(img, 100, 10);
            ctx.fillText("Your order has been placed.", 130, 90);
            ctx.fillText('Your order number is "' + data[0]+ '"', 110, 120);
            ctx.fillText('We will call your number "' + data[1] + '" to reconfirm ', 20, 150);

           
            var link = document.createElement('a');
            link.download = 'LP_Order_Info.png';
            link.href = c.toDataURL("image/png").replace("image/png", "image/octet-stream");
            document.body.appendChild(link);
            link.click();
        }
        this.Render = function (container, orderInfo) {
            view.Container = container.empty();
            resetMenu(false);
            AppBase.State.Set({
                Param: [container],
            }, 'OrderInfo', '/ProductOrderArea/ProductOrder/GetInfo?Id=' + orderInfo.Id);
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'OrderInfo', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="info_container">'));
            container.append(Global.Click($('<button class="btn btn-success btn-default btn-round pull-right hide_on_mobile" type="button" style="margin-top: 1%;margin-right: 5%; "><span class="glyphicon glyphicon-upload"></span> Print Here </button>'), PrintElem, 'printable'));

            container.append($('<div class="row"></div>').append(Global.Click($('<a class="btn btn-success btn-default btn-round pull-right CheckButton" type="button" style="margin-top: 1%;margin-right: 2%; "><span class="glyphicon glyphicon-upload"></span> Download</a>'), GetImage, [orderInfo.OrderNo, orderInfo.Number] )));
            container.append(container = $('<div class="order_info col-md-12" id="printable">'));
            container.append(container = $('<div style="text-align:center">'));

            container.append('<img id="lazz" src="/Content/assets/images/Lazz_Logo_305x50.png" /> <hr/>');
            container.append('<p style="color: red">Your order has been placed.</p>');
            container.append('<p style="color: red">Your order number is "' + orderInfo.OrderNo + '"</p>');
            container.append('<p style="color: red"> We will call your number "' + orderInfo.Number + '" to reconfirm </p>');
            setFooterNotice(container);
            return view.Container
        };
    }).call(view.OrderInfo = {}, view);

    (function (parent) {
        var view = { Parent: parent };
        function PrintElem(elem) {
            var mywindow = window.open('', 'PRINT', 'height=400,width=600');
            mywindow.document.write(document.getElementById(elem).innerHTML);
            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10*/
            mywindow.print();
            mywindow.close();
            return true;
        }
        this.Render = function (container, orderInfo) {
            view.Container = container.empty();
            resetMenu(false);
            AppBase.State.Set({
                Param: [container],
            }, 'OrderInfo', '/ProductOrderArea/ProductOrder/CancelPayment?Id=' + orderInfo.Id);
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'OrderInfo', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="info_container">'));
            container.append(Global.Click($('<button class="btn btn-success btn-default btn-round pull-right hide_on_mobile" type="button" style="margin-top: 1%;margin-right: 5%; "><span class="glyphicon glyphicon-upload"></span> Print Here </button>'), PrintElem, 'printable'));
            container.append(container = $('<div class="order_info col-md-12" id="printable">'));
            container.append(container = $('<div style="text-align:center">'));
            container.append('<img src="/Content/assets/images/Lazz_Logo_305x50.png" /> <hr/>');
            container.append('<p style="color: red">Your order has been placed.</p>');
            container.append('<p style="color: red">Your order number is "' + orderInfo.OrderNo + '"</p>');
            container.append('<p style="color: red"> We will call your number "' + orderInfo.Number + '" to reconfirm </p>');
            setFooterNotice(container);
            return view.Container
        };
    }).call(view.CancleOrderInfo = {}, view);
    (function (parent) {
        var view = { Parent: parent };
        function PrintElem(elem) {
            var mywindow = window.open('', 'PRINT', 'height=400,width=600');
            mywindow.document.write(document.getElementById(elem).innerHTML);
            mywindow.document.close(); // necessary for IE >= 10
            mywindow.focus(); // necessary for IE >= 10*/
            mywindow.print();
            mywindow.close();
            return true;
        }
        this.Render = function (container, orderInfo) {
            view.Container = container.empty();
            resetMenu(false);
            AppBase.State.Set({
                Param: [container],
            }, 'OrderInfo', '/ProductOrderArea/ProductOrder/FailPayment?Id=' + orderInfo.Id);
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'OrderInfo', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="info_container">'));
            container.append(Global.Click($('<button class="btn btn-success btn-default btn-round pull-right hide_on_mobile" type="button" style="margin-top: 1%;margin-right: 5%; "><span class="glyphicon glyphicon-upload"></span> Print Here </button>'), PrintElem, 'printable'));
            container.append(container = $('<div class="order_info col-md-12" id="printable">'));
            container.append(container = $('<div style="text-align:center">'));
            container.append('<img src="/Content/assets/images/Lazz_Logo_305x50.png" /> <hr/>');
            container.append('<p style="color: red">Your order has been placed.</p>');
            container.append('<p style="color: red">Your order number is "' + orderInfo.OrderNo + '"</p>');
            container.append('<p style="color: red"> We will call your number "' + orderInfo.Number + '" to reconfirm </p>');
            setFooterNotice(container);
            return view.Container
        };
    }).call(view.FailOrderInfo = {}, view);


    (function (parent) {
        var view = { Parent: parent }, formModel = {};
        function getModel() {
            model = {
                Name: formModel.Name,
                Mobile: formModel.Mobile,
                Email: formModel.Email,
                Massege: formModel.Massege,
                ActivityId: formModel.ActivityId
            };
            return model;
        };
        function isValid(model) {
            var pattern = /^(?:\+88|01)?(?:\d{11}|\d{13})$/;
            if (!formModel.Name) {
                alert('Please enter your name.');
                return false;
            }
            if (!formModel.Mobile || !pattern.test(formModel.Mobile)) {
                alert('Please Enter a Bangladeshi Phone number.');
                return false;
            }
            return true;
        };
        function save(model) {
            var model = model || getModel();
            if (!isValid(model)) {
                return;
            }
            //console.log(['formModel', formModel]);
            Global.Busy();
            Global.CallServer('/ContactArea/Contact/Add', function (response) {
                Global.Free();
                if (!response.IsError) {
                    alert('Message Sent Successfully');
                    formModel.Name = "",
                        formModel.Mobile = "",
                        formModel.Email = "",
                        formModel.Massege = ""
                } else {
                    alert(response.Msg || 'Errors!!!!!.');
                }
            }, function () {
                Global.Free();
            }, model);
        };
        this.Render = function (container) {
            view.Container = container.empty();
            resetMenu(7);
            AppBase.State.Set({
                Param: [container],
                Component: parent.ContactUs,
            }, 'ContactUsPage', '/Home/ContactUs');

            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'Contact Us', view.Parent.Home.Render, view.Parent.Home.Container);

            function contactForm(container) {
                container.append(container = $('<div id="form_container" class="col-md-9">'));
                getTextAreaSectionWithTitle(container, formModel, 'Massege', 'Your Message', 'col-sm-12 form-group');
                getSectionWithTitle(container, formModel, 'Name', 'Your Name', 'col-sm-4 form-group');
                getSectionWithTitle(container, formModel, 'Mobile', 'Your Mobile', 'col-sm-4 form-group');
                getSectionWithTitle(container, formModel, 'Email (Optional) ', 'Your Email (Optional)', 'col-sm-4 form-group');
                container.append(container = $(Global.Click($('<div class= "col-sm-12 text-right form-group">' +
                    '<button class="External_Block_Button" style="width: 20%;font-size: 18px;padding: 1%;" type="button">SEND </button></div>'), save)));
            };

            function companyInfo(container) {
                container.append(container = $('<div class="col-md-3">'));
                container.append(elm = $('<h3 class="contact_info">Whatever You want, Let us Know </h3>'));
                elm.append(elm = $('<div class="row contact_info">'));
                elm.append($('<div class="col-sm-12 contact_info">' + '<h4> Call Us: </h4> <p class="contact_info"> +880258155933, 01319864049 </p>' + '</div>'));
                elm.append($('<div class="col-sm-12 contact_info">' + '<h4> Email Us: </h4><p class="contact_info"> lazzcorporate@gmail.com</p>' + '</div>'));

            };


            container.append(container = $('<div class="container">'));
            container.append($('<h2> Please send your message below. We will get back to you at the earliest! </h2>'));
            container.append(container = $('<div class="row">'));
            contactForm(container);
            companyInfo(container);

            return view.Container
        };
    }).call(view.ContactUs = {}, view);

    (function (parent) {
        var view = { Parent: parent }, isActive, resultContainer, page = { 'PageNumber': 1, 'PageSize': 10 }, categoryId = '';

        function productGrid(container) {
            container.append(container = $('<div id="view-product-list" class="view-product-list">'));
            container.append(resultContainer = container = $('<ul class="row product-list grid">'));
            return container;
        };
        function create(container, data) {
            var elm;
            var oldPrice = '', price = data.UnitSalePrice;
            if (data.Discount > 0) {
                price = data.UnitSalePrice - data.UnitSalePrice.mlt(data.Discount).div(100);
                oldPrice = '<del style="color:red; font-weight: normal;">৳ ' + Math.round(data.UnitSalePrice) + '</del>';
            }
            container.append(container = $('<li class="col-xs-6 col-sm-2 col-md-2">'));
            container.append(container = $('<div class="product-container">'));
            container.append(elm = $('<div class="left-block">' +
                '<a><img class="search_product_image" src="' + AppBase.GetImagePath(data, 'Small', '/Content/assets/images/med.jpg') + '" /></a>' +
                + '</div>'));
            container.append($('<div class="right-block">' +
                ' <h3 class="product-name" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;"><a href="/ProductArea/Product/Details?Id=' + data.Id + '">' + data.Name + '<span> ' + data.Strength + '</span>' + '</a></h3><span>' +
                '<div class="product_des">' + data.Suplier + '</div>' +
                '<div class="product_gen">' + data.GenericName + '</span></div>' +
                '<div class="unit_text"><span> Type - ' + data.Category + '</span></div>' +
                '<div class="content_price"><span class="price product-price">৳ ' + price.toFloat(1) + '</span><span class="price old-price">' + oldPrice + '</span></div>' +
                +'</div>'));
            container.append(AppBase.Click($('<div style="text-align: center"><div style="margin-top: 2%;"><a class="btn_add_to_cart" title="Add to Cart">Add to Cart</a></div></div>'), function (evnt, container, data) {
                var elm = container.closest('.product-container');
                AppBase.CartBox.Add(data, elm, evnt);
                //AppBase.CartBox
            }, container, data));
        };
        function nodata(container) {
            container.append(container = $('<div class="info_container">'));
            container.append(container = $('<div class="order_info col-md-12">'));
            container.append('<h2>No Data Found</h2>');
        };
        function showData(container, list) {
            var item;
            list.each(function () {
                item = {
                    "Id": this[0],
                    "Name": this[1],
                    "GenericName": this[2],
                    "Strength": this[3],
                    "UnitSalePrice": this[4],
                    "Discount": this[5],
                    "ImagePath": this[6],
                    "ImageType": this[7],
                    "Category": this[8],
                    "Suplier": this[9],
                };
                create(container, item);
            });
        };
        function setWaiting(container) {
            var elm;
            container.append(container = $('<li class="col-sx-12 col-sm-4 col-md-3">'));
            container.append(elm = $('<div class="product-container">'));
            elm.append(elm = $('<img class="search_product_image" src="/Content/IqraService/Img/Spin-1s-80px.gif" />'));
            return container;
        };

        function onLoad(id, page, func) {
            Global.CallServer('/ProductArea/ProductCategory/Details?Id=' + id, function (response) {
                if (!response.IsError) {
                    func(response.Data);
                } else {
                }
            }, function (response) {
                response.Id = -8;
            }, page, 'POST');

        };

        (function () {
            function onScroll() {
                if (isActive && !view.AllLoaded && !view.IsLoading && ($(document.body).height() - window.innerHeight - window.scrollY - $('#footer').height() < 350)) {
                   if (view.SearchEvent) {
                        clearTimeout(view.SearchEvent);
                    }
                    view.SearchEvent = setTimeout(function () {
                        page.PageNumber++;
                        view.IsLoading = true;
                        var waiting = setWaiting(resultContainer);

                        onLoad(categoryId, page, function (data) {
                            waiting.remove();
                            view.IsLoading = false;
                            view.AllLoaded = data.length < page.PageSize;
                            showData(resultContainer, data);
                        });
                    }, 150);
                }
            };
            $(document).scroll(function (e) {
                onScroll();
            });
            document.body.onwheel = function (e) {
                onScroll();
            };
        })();

        this.Render = function (container, id, filter, txt) {
            categoryId = id;
            view.Container = container.empty();
            resetMenu(false);

            $(document).ready(function () {
                var menu = ".vertical-menu-list";
                $(menu).hide();
                setTimeout(function () {
                    $(menu).fadeIn();
                }, 1000)
            });

            AppBase.State.Set({
                Param: [container, id],
                Component: parent.ProductCategoryDetails,
            }, 'ProductCategoryDetails', '/ProductCategoryDetails?Id=' + categoryId)
            isActive = true;
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'ProductCategory', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="result_container row">'));
            container = productGrid(container);
            var waiting = setWaiting(resultContainer);
            onLoad(id, page = { 'PageNumber': 1, 'PageSize': 20 }, function (data) {
                waiting.remove();
                view.AllLoaded = false;
                container.empty();
                if (data.length > 0) {
                    showData(container, data);
                }
                else {
                    nodata(container);
                }
            });
            return view.Container
        };
    }).call(view.ProductCategoryDetails = {}, view);

    (function (parent) {
        var view = { Parent: parent }, isActive, resultContainer, page = { 'PageNumber': 1, 'PageSize': 10 }, subcategoryId = '';

        function productGrid(container) {
            container.append(container = $('<div id="view-product-list" class="view-product-list">'));
            //container.append($('<ul class="display-product-option">' +
            //    '<li class="view-as-grid selected"><span>grid</span></li>' +
            //    '<li class="view-as-list"><span>list</span></li>' +
            //    + '</ul>'));
            container.append(resultContainer = container = $('<ul class="row product-list grid">'));

            return container;
        };
        function create(container, data) {
            var elm;
            var oldPrice = '', price = data.UnitSalePrice;
            if (data.Discount > 0) {
                price = data.UnitSalePrice - data.UnitSalePrice.mlt(data.Discount).div(100);
                oldPrice = '<del style="color:red; font-weight: normal;">৳ ' + Math.round(data.UnitSalePrice) + '</del>';
            }
            container.append(container = $('<li class="col-xs-6 col-sm-2 col-md-2">'));
            container.append(container = $('<div class="product-container">'));
            container.append(elm = $('<div class="left-block">' +
                '<a><img class="search_product_image" src="' + AppBase.GetImagePath(data, 'Small', '/Content/assets/images/med.jpg') + '" /></a>' +
                + '</div>'));

           

            container.append($('<div class="right-block">' +
                ' <h3 class="product-name" style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap;"><a href="/ProductArea/Product/Details?Id=' + data.Id + '">' + data.Name + '<span> ' + data.Strength + '</span>' + '</a></h3><span>' +
                '<div class="product_des">' + data.Suplier + '</div>' +
                '<div class="product_gen">' + data.GenericName + '</span></div>' +
                '<div class="unit_text"><span> Type - ' + data.Category + '</span></div>' +
                '<div class="content_price"><span class="price product-price">৳ ' + price.toFloat(1) + '</span><span class="price old-price">' + oldPrice + '</span></div>' +
                +'</div>'));


            container.append(AppBase.Click($('<div style="text-align: center"><div style="margin-top: 2%;"><a class="btn_add_to_cart" title="Add to Cart">Add to Cart</a></div></div>'), function (evnt, container, data) {
                var elm = container.closest('.product-container');
                AppBase.CartBox.Add(data, elm, evnt);
                //AppBase.CartBox
            }, container, data));

        };
        function nodata(container) {
            container.append(container = $('<div class="info_container">'));
            container.append(container = $('<div class="order_info col-md-12">'));
            container.append('<h2>No Data Found</h2>');
        };
        function showData(container, list) {
            var item;
            list.each(function () {
                item = {
                    "Id": this[0],
                    "Name": this[1],
                    "GenericName": this[2],
                    "Strength": this[3],
                    "UnitSalePrice": this[4],
                    "Discount": this[5],
                    "ImagePath": this[6],
                    "ImageType": this[7],
                    "Category": this[8],
                    "Suplier": this[9],
                };
                
                create(container, item);
            });
        };
        function setWaiting(container) {
            var elm;
            container.append(container = $('<li class="col-sx-12 col-sm-4 col-md-3">'));
            container.append(elm = $('<div class="product-container">'));
            elm.append(elm = $('<img class="search_product_image" src="/Content/IqraService/Img/Spin-1s-80px.gif" />'));
            return container;
        };
        
        function onLoad(id, page, func) {
            Global.CallServer('/ProductArea/ProductSubCategory/Details?Id=' + id, function (response) {
                if (!response.IsError) {
                    func(response.Data);
                } else {

                }
            }, function (response) {
                response.Id = -8;
            }, page, 'POST');

        };
        (function () {
            function onScroll() {
                if (isActive && !view.AllLoaded && !view.IsLoading && ($(document.body).height() - window.innerHeight - window.scrollY - $('#footer').height() < 350)) {
                    //console.log(['onScroll', $(document.body).height(), window.scrollMaxY, window.innerHeight, window.scrollY, window.scrollMaxY - window.innerHeight - window.scrollY]);
                    if (view.SearchEvent) {
                        clearTimeout(view.SearchEvent);
                    }
                    view.SearchEvent = setTimeout(function () {
                        page.PageNumber++;
                        view.IsLoading = true;
                        var waiting = setWaiting(resultContainer);

                        onLoad(subcategoryId, page, function (data) {
                            waiting.remove();
                            view.IsLoading = false;
                            //console.log(['AllLoaded', view.AllLoaded, data.length, page.PageSize]);
                            view.AllLoaded = data.length < page.PageSize;
                            showData(resultContainer, data);

                        });
                    }, 150);
                }
            };
            $(document).scroll(function (e) {
                onScroll();
            });
            document.body.onwheel = function (e) {
                onScroll();
            };
        })();

        this.Render = function (container, id, filter, txt) {
            subcategoryId = id;
            view.Container = container.empty();
            resetMenu(false);
            $(document).ready(function () {
                var menu = ".vertical-menu-list";
                $(menu).hide();
                setTimeout(function () {
                    $(menu).fadeIn();
                }, 1000)
            });
            AppBase.State.Set({
                Param: [container, id],
                Component: parent.ProductSubCategoryDetails,
            }, 'ProductSubCategoryDetails', '/ProductSubCategoryDetails?Id=' + subcategoryId)
            isActive = true;
            BodyParent.NavTopMenu.Reset();
            setSummary(container, 'ProductSubCategory', view.Parent.Home.Render, view.Parent.Home.Container);
            container.append(container = $('<div class="result_container row">'));
            container = productGrid(container);
            var waiting = setWaiting(resultContainer);
            onLoad(id, page = { 'PageNumber': 1, 'PageSize': 20 }, function (data) {
                waiting.remove();
                view.AllLoaded = false;
                container.empty();
                if (data.length > 0) {
                    showData(container, data);
                }else {
                    nodata(container);
                }
            });
            return view.Container
        };
    }).call(view.ProductSubCategoryDetails = {}, view);
    this.Render = function (container, index, func) {
        view.Container = container.empty();
        container = BodyParent.Container = $('<div id="body_content">');
        view.Container.append(view.NavTopMenu.Render($('<div id="nav-top-menu" class="nav-top-menu home">'), container));
        view.Container.append(container);
        if (index !== false) {
            index = index || 0;
            items[index] && items[index].elm.click();
        }
        AppBase.CartBox.Render(view.Container);
        func && func(container, view.Container, view);
        return view.Container
    };
}).call(BodyParent);

