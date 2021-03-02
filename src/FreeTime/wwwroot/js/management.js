$(document).on("click", ".btn-delete-post", function () {
    var id = $(this).data('id');
    deletePost(id);
});

function deleteRecord(id,url){

    Swal.fire({
        title: 'Are you sure to delete this item?',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Delete',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            $.ajax({
                url:url,
                method: 'DELETE',
                headers: {
                    "Content-Type": "application/json"
                },
                success: function (res) {
                    $(`tr#${id}`).remove();
                },
                error: function (res) {
                    console.log();
                    if (res.status == 401) {
                        Swal.fire({
                            title: `You need to sign-in`,
                            icon: 'error',
                        })
                    }
                    else {
                        Swal.fire({
                            title: `An error has been occured`,
                            icon: 'error',
                        })
                    }
                }
            });
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: `Item has been deleted`,
                icon: 'success',
            })
        }
    })

}

function deletePost(id) {
    deleteRecord(id, `${baseUrl}admin/post/${id}`);
}

function deleteComment(id) {
    deleteRecord(id, `${baseUrl}admin/comment/${id}`);
}