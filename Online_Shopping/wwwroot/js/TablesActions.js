let pagenumber = 1;

/* can make next and prev function  dynamic and pass pramter
  tableId,url,list count,htmlbody if we will use it in more than screen
 */

function NextPage(listCount) {

   

    pagenumber++;
    
    if (pagenumber * 10 > listCount) {
        pagenumber = Math.ceil(listCount / 10);
        return;

    }
        
    $("#TableBody").empty();
    $.ajax({
        type: "GET",
        url: `/Product/Pagination`,
        data: { PageNumber: pagenumber, PageSize: 10 },
        success: function (res) {
            console.log(res);
            res.forEach(item => {
                $("#TableBody").append(`


                                     <tr>
                                    <th scope="row">${item.id}</th>
                                    <td>${item.localName}</td>
                                    <td>${item.latinName}</td>
                                       <td>
                                           <img src="/imges/${item.imgeName}" class="w-25 rounded-circle"/>

                                       </td>
                                      <td>${item.Description}</td>
                                       <td>${item.categoryName}</td>
                                    <td>${item.subCategoryName}</td>



                                </tr>



                            `)
            })


        }

    });
    
};
function PreviousPage() {

    pagenumber--;
    if (pagenumber <= 0) {
        pagenumber = 1;
        return;
    }

   

    
         
   
    $("#TableBody").empty();
    $.ajax({
        type: "GET",
        url: `/Product/Pagination`,
        data: { PageNumber: pagenumber, PageSize: 10 },
        success: function (res) {
            console.log(res,"Prev");
            res.forEach(item => {
                $("#TableBody").append(`
                    <tr>
                                    <th scope="row">${item.id}</th>
                                    <td>${item.localName}</td>
                                    <td>${item.latinName}</td>
                                       <td>
                                           <img src="/imges/${item.imgeName}" class="w-25 rounded-circle"/>

                                       </td>
                                      <td>${item.Description}</td>
                                       <td>${item.categoryName}</td>
                                    <td>${item.subCategoryName}</td>



                                </tr>



                                    `)
            })


        }

    });
    
       
};