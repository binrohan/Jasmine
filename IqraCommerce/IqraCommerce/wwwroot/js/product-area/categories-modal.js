var Controller = new function () {
    const filter = [{ "field": "IsDeleted", "value": 0, Operation: 0 },
                { "field": "IsVisible", "value": 1, Operation: 0 }];

    const commonGridConfig = (Header, Url, filter = [], ) => ({
        Header,
        Columns: [
            { field: 'Name', title: 'Name', filter: true, add: { sibling: 2 } },
            { field: 'Hierarchy', title: 'Hierarchy', add: false, Width: '600px' }
        ],
        onDataBinding: function (response) {
            response.Data.Data.each(function () {

            });
        },
        selector: false,
        Printable: {
            container: $('void')
        }
    })

    const addToTheCategory = () => {

    }

    this.Show = function (options) {
        Global.Add({
            title: 'Add To Categories',
            selected: 0,
            Tabs: [
                {
                    title: 'Add To Category',
                    Grid: [{
                        Header: 'Catgories',
                        Columns: [
                            { field: 'Name', title: 'Name', filter: true, add: { sibling: 2 } },
                            { field: 'Hierarchy', title: 'Hierarchy', add: false, Width: '600px' },
                        ],
                        Url: '/Category/Get',
                        filter: [...filter],
                        onDataBinding: function (response) {
                            response.Data.Data.each(function () {

                            });
                        },
                        actions: [
                            {
                                click: addToTheCategory,
                                html: `<a class="action-button info t-white"><i class="glyphicon glyphicon-plus" title="${"Add to this category"}"></i></a>`
                            }
                        ],
                        selector: false,
                        Printable: {
                            container: $('void')
                        }
                    }],
                },
                {
                    title: 'Product\'s Categories',
                    Grid: [{
                        Header: 'Catgories',
                        Columns: [
                            { field: 'Name', title: 'Name', filter: true, add: { sibling: 2 } },
                            { field: 'Hierarchy', title: 'Hierarchy', add: false, Width: '600px' },
                        ],
                        Url: '/Category/Get',
                        filter: [...filter],
                        onDataBinding: function (response) {
                            response.Data.Data.each(function () {

                            });
                        },
                        selector: false,
                        Printable: { container: $('void')}
                    }],
                }
            ],
            name: 'OnOrderDetails',
            url: '/lib/IqraService/Js/OnDetailsWithTab.js?v=OrderDetails',
        });
    };
};