
// With validation
$(function () {
 
 


    var $form = $('#smartwizard-1');
    var $btnFinish = $('<button class="btn-finish btn btn-primary hidden mr-2" type="button">Bitir</button>');

    // Initialize wizard
    $form
        .smartWizard({
            autoAdjustHeight: false,
            backButtonSupport: false,
            useURLhash: false,
            showStepURLhash: false,
            toolbarSettings: {
                toolbarExtraButtons: [$btnFinish]
            },
            lang: {
                next: 'Ileri',
                previous: 'Geri'
            },
        })
        .on('leaveStep', function (e, anchorObject, stepNumber, stepDirection) {
            // stepDirection === 'forward' :- this condition allows to do the form validation
            // only on forward navigation, that makes easy navigation on backwards still do the validation when going next
            // if (stepDirection === 'forward'){ return $form.valid(); }
            return true;
        })
        .on('showStep', function (e, anchorObject, stepNumber, stepDirection) {
            var $btn = $form.find('.btn-finish');

            // Enable finish button only on last step
            if (stepNumber === 3) {
                $btn.removeClass('hidden');
            } else {
                $btn.addClass('hidden');
            }
        });

    // Click on finish button
    $form.find('.btn-finish').on('click', function () {
        //if (!$form.valid()){ return; }

        // Submit form
        alert("Great! We're ready to submit form.");
        return false;
    });






    $('#bs-markdown').markdown({
        iconlibrary: 'fa',
        footer: '<div id="md-character-footer"></div><small id="md-character-counter" class="text-muted">350 character left</small>',

        onChange: function (e) {
            var contentLength = e.getContent().length;

            if (contentLength > 350) {
                $('#md-character-counter')
                    .removeClass('text-muted')
                    .addClass('text-danger')
                    .html((contentLength - 350) + ' character surplus.');
            } else {
                $('#md-character-counter')
                    .removeClass('text-danger')
                    .addClass('text-muted')
                    .html((350 - contentLength) + ' character left.');
            }
        },
    });

    // Update character counter
    $('#markdown').trigger('change');


    // *******************************************************************
    // Fix icons

    $('.md-editor .fa-header').removeClass('fa fa-header').addClass('fas fa-heading');
    $('.md-editor .fa-picture-o').removeClass('fa fa-picture-o').addClass('far fa-image');













});
