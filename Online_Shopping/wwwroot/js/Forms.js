function ClearElements(elementId) {
    $("#" + elementId).empty();
}
console.log("Hi Forms");
function getSubCategoriesByCategoryId(categoryId) {

    $.ajax({
        type: "GET",
        url: `/SubCategory/GetSubCategoriesByCategoryId`,
        data: { categoryId: categoryId },
        success: function (res) {
           
            PutDataptionsElement(res);
        }

    });

}
function PutDataptionsElement(data) {
    $("#subCategoryId").prop('disabled', false);
    $("#subCategoryId").append(`<option value="NULL">Select Value</option>`);
    data.forEach((item) => {
        $("#subCategoryId").append(`<option value="${item.id}"> ${item.name}</option>`);
    })

}

document.getElementById("categoryId").addEventListener("change", (event) => {
    ClearElements("subCategoryId");
    // console.log(event.target.value);
    getSubCategoriesByCategoryId(event.target.value);
});