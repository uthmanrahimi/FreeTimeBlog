$(document).on("click", ".btn-delete-post", function () {
    var id = $(this).data('id');
    deletePost(id);
});

function deletePost(id) {
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
                url: `${baseUrl}api/blog/${id}`,
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