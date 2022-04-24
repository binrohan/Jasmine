
var Controller = new function () {
    const liveRecord = { "field": "IsDeleted", "value": 0, Operation: 0 };
    const festivalFilter = { "field": "FestivalId", "value": '', Operation: 0 }
    
    let _callerOptions;

    const addToFestival = (productId, festivalId, grid) => {
        const formData = new FormData();
        formData.append('productId', productId);
        formData.append('festivalId', festivalId);

       fetch('/FestivalProduct/Create', {
           method: 'POST',
           body: formData
       }).then(res => res.json())
       .then(data => {
           
           if(data.IsError)
            throw new Error(data.Msg)

            grid.Reload();
            // Toaster will be perfact here
            alert("Successfully product added to the festival");

       }).catch((err) => {
            alert(err);
        });
    }

    const removeFromFestival = (id, grid) => {
        const formData = new FormData();
        formData.append('id', id);

       fetch('/FestivalProduct/Remove', {
           method: 'PUT',
           body: formData
       }).then(res => res.json())
       .then(data => {

           if(data.IsError)
            throw new Error(data.Msg)

            grid.Reload();

            // Toaster will be perfact here
            alert("Successfully product remove from the festival");

       }).catch((err) => {
            alert(err);
       });
    }

    this.Show = function (options) {
        _callerOptions = options;
        festivalFilter.value = _callerOptions.festivalId;

        Global.Add({
            title: 'Products',
            selected: 0,
            Tabs: [
                {
                    title: 'Festival\'s Products',
                    Grid: [{
                        Header: 'Catgories',
                        Columns: [
                            { field: 'Name', title: 'Name', filter: true, position: 1 },
                            { field: 'CurrentPrice', title: 'Current Price', filter: true, position: 3 },
                            { field: 'OriginalPrice', title: 'Original Price', filter: true, position: 3 },
                            { field: 'StockUnit', title: 'Stock', filter: true, position: 7 },
                            { field: 'PackSize', title: 'Pack Size', filter: true, position: 9 },
                            { field: 'UnitName', title: 'Unit', filter: true, add: false },
                        ],
                        Url: '/FestivalProduct/GetProductsByFestival',
                        filter: [liveRecord, festivalFilter],
                        onDataBinding: () => {},
                        actions: [
                            {
                                click: (row, grid) => removeFromFestival(row.Id, grid),
                                html: `<a class="action-button info t-white"><i class="glyphicon glyphicon-remove" title="${"Remove From Festival"}"></i></a>`
                            }
                        ],
                        selector: false,
                        Printable: {
                            container: $('void')
                        }
                    }],
                },
                {
                    title: 'All Products',
                    Grid: [{
                        Header: 'All Products',
                        Columns: [
                            { field: 'Name', title: 'Name', filter: true, position: 1 },
                            { field: 'CurrentPrice', title: 'Current Price', filter: true, position: 3 },
                            { field: 'OriginalPrice', title: 'Original Price', filter: true, position: 3 },
                            { field: 'StockUnit', title: 'Stock', filter: true, position: 7 },
                            { field: 'PackSize', title: 'Pack Size', filter: true, position: 9 },
                            { field: 'UnitName', title: 'Unit', filter: true, add: false },
                        ],
                        Url: '/Product/Get/',
                        filter: [liveRecord],
                        onDataBinding: () => {},
                        actions: [
                            {
                                click: (row, grid) => addToFestival(row.Id, _callerOptions.festivalId, grid),
                                html: `<a class="action-button info t-white"><i class="glyphicon glyphicon-plus" title="${"Add to the Festival"}"></i></a>`
                            }
                        ],
                        selector: false,
                        Printable: {
                            container: $('void')
                        }
                    }],
                }
            ],
            name: 'OnOrderDetails',
            url: '/lib/IqraService/Js/OnDetailsWithTab.js?v=OrderDetails',
        });
    };
};