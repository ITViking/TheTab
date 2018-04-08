// Write your JavaScript code.
$(document).ready(


    function () {
        function item(_name, _price, _id) {
            this.Id = _id;
            this.Name = _name;
            this.Price = _price;
        }

        var items = new Array();
        var total = document.getElementById("total");
        var productCount = document.getElementById("productCount")
        var allPrices = 0;
        $(".selectiontable button").click(function () {
            $(".receipt").removeClass("hidden");
            var element = $(this);
            var itemId = element.attr("id");
            var itemName = element.attr("value");
            var itemPrice = element.parent("td").siblings().children("label").attr("title");
            
           
            var newRowContent = "<div class='row removeable' value=" + itemPrice + ">"+
                                "<div class='col-xs-8'>" + itemName + "</div>"+
                                "<div class='col-xs-4'>" + itemPrice + "</div>"+
                                "</div>";

            $(newRowContent).insertBefore($(".barhr"));
            allPrices += parseInt(itemPrice);
            total.innerHTML = allPrices + " kr";
            
            items.push(new item(itemName, itemPrice, itemId));

            productCount.innerHTML = "Total  (" + items.length + " Varer)";
        });

        $(document).on("click", "div.removeable", function () {
            var itemToRemove = $(this);
            var deduction = itemToRemove.attr("value");

            allPrices -= parseInt(deduction);
            total.innerHTML =  allPrices + " kr";
            itemToRemove.remove();            

            var removeables = $(document.getElementsByClassName("removeable"));
            if (removeables.length === 0) {
                $(".receipt").addClass("hidden");
            }
            var objectToRemove = new item($(this).attr("value"), $(this).parent("td").siblings().children("label").attr("title"));
            items.splice($.inArray(objectToRemove, items), 1);
            productCount.innerHTML = "Total  (" + items.length + " Varer)";
        });

        $(document).on("click", "#submitButton", function () {

            $.ajax({
                type: 'post',
                url: '/Bar/Index',
                data: { 'items': JSON.stringify(items) },                

                dataType: 'text',
                success: function (response) {
                    var redirectUrl = JSON.parse(response);
                    window.location.href = redirectUrl.redirectToUrl.toString();
                },
                error: function (e) {
                    alert(e.message);
                }
            })

        });

        $(".clickable-row").click(function () {
            window.location = $(this).data("href");
        })
    }
);//End of docuement ready