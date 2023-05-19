let pagenumber = 2;
let prevNumber = pagenumber-1;
function NextPage(listCount) {

   
    console.log(pagenumber, listCount);
     prevNumber = pagenumber - 1;
    console.log(pagenumber * 1 > listCount);
    if (pagenumber * 1 > listCount)
        return;
    $("#TableBody").empty();
    $.ajax({
        type: "GET",
        url: `/Product/Pagination`,
        data: { PageNumber: pagenumber, PageSize: 1 },
        success: function (res) {
            console.log(res);
            res.forEach(item => {
                $("#TableBody").append(`


                                     <tr>
                                    <td scope="row">${item.id}</td>
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
    pagenumber++;
};
function PreviousPage() {
    console.log(prevNumber, "Prev");
    if (prevNumber <= 0)
        return;

    
         
   
    $("#TableBody").empty();
    $.ajax({
        type: "GET",
        url: `/Product/Pagination`,
        data: { PageNumber: prevNumber, PageSize: 1 },
        success: function (res) {
            console.log(res,"Prev");
            res.forEach(item => {
                $("#TableBody").append(`
                    <tr>
                                    <td scope="row">${item.id}</td>
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
    if (prevNumber>1)
        pagenumber--;
};