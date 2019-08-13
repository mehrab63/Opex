$(document).ready(function () {
    $("#phwone").keyup(function () {
        isNumber($(this));
        $(this).val($(this).val().replace(/^(\d{4})(\d{3})(\d{4})+$/, "$1-$2-$3"));
    });
});
function isValid(evr) {
    var phoneNumber = document.getElementById('phone').value;
    var validPhone = /^(\d{4})(\d{3})(\d{4})+$/; 
    if (validPhone.test(phoneNumber)) {
        document.getElementById('phone').style.backgroundColor = '#d4edda'; 
    } else {
        
    }
    var regular = /^(\+98|0)?9\d{9}$/;
    if (regular.test(phoneNumber)) {
        $("#vali").removeClass("text-danger");
        $("#vali").text(" ");
        $("#vali").addClass("text-success");
        $("#vali").addClass("glyphicon glyphicon-ok");
        
    } else {
        document.getElementById('phone').style.backgroundColor = '#f2dede';
        $("#vali").removeClass("glyphicon glyphicon-ok");
        $("#vali").addClass("text-danger");
        $("#vali").text("شماره نامعتبر")
    }
}
function isNumber(evt) {
   
    var iKeyCode = (evt.which) ? evt.which : evt.keyCode
    if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
        return false;
    return true;
}
 
function numberWithCommas(val) {
        var parts = val.toString().split(".");
        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        return parts.join(".");
    }

function checkReading() {
    if (checkReading.read) {
        return;
    }
    checkReading.read = this.scrollHeight - this.scrollTop === this.clientHeight;
    document.registration.accept.disabled = document.getElementById("nextstep").disabled = !checkReading.read;
    checkReading.noticeBox.innerHTML = checkReading.read ? "Thank you." : "Please, scroll and read the following text.";
}

onload = function () {
    var oToBeRead = document.getElementById("rules");
    checkReading.noticeBox = document.createElement("span");
    document.registration.accept.checked = false;
    checkReading.noticeBox.id = "notice";
    oToBeRead.parentNode.insertBefore(checkReading.noticeBox, oToBeRead);
    oToBeRead.parentNode.insertBefore(document.createElement("br"), oToBeRead);
    oToBeRead.onscroll = checkReading;
    checkReading.call(oToBeRead);
}
var show = function (elem) {

    // Get the natural height of the element
    var getHeight = function () {
        elem.style.display = 'block'; // Make it visible
        var height = elem.scrollHeight + 'px'; // Get it's height
        elem.style.display = ''; //  Hide it again
        return height;
    };

    var height = getHeight(); // Get the natural height
    elem.classList.add('is-visible'); // Make the element visible
    elem.style.height = height; // Update the max-height

    // Once the transition is complete, remove the inline max-height so the content can scale responsively
    window.setTimeout(function () {
        elem.style.height = '';
    }, 350);

};

// Hide an element
var hide = function (elem) {

    // Give the element a height to change from
    elem.style.height = elem.scrollHeight + 'px';

    // Set the height back to 0
    window.setTimeout(function () {
        elem.style.height = '0';
    }, 1);

    // When the transition is complete, hide it
    window.setTimeout(function () {
        elem.classList.remove('is-visible');
    }, 350);

};

// Toggle element visibility
var toggle = function (elem, timing) {

    // If the element is visible, hide it
    if (elem.classList.contains('is-visible')) {
        hide(elem);
        return;
    }

    // Otherwise, show it
    show(elem);

};

// Listen for click events
document.addEventListener('click', function (event) {
    // Make sure clicked element is our toggle
    if (!event.target.classList.contains('toggle')) return;

    // Prevent default link behavior
    event.preventDefault();

    // Get the content
    var content = document.querySelector(event.target.hash);
    if (!content) return;

    // Toggle the content
    toggle(content);
    66898002
}, false);
var catAndActs = {};
catAndActs['01'] = ['آذرشهر', 'اسکو', 'اهر', 'بستان‌آباد', 'بناب', 'تبریز', 'جلفا', 'چاراویماق', 'سراب', 'شبستر', 'عجب‌شیر', 'کلیبر', 'مراغه', 'مرند', 'ملکان', 'میانه', 'ورزقان', 'هریس', 'هشترود'];
catAndActs['02'] = ['ارومیه', 'اشنویه', 'بوکان', 'پیرانشهر', 'تکاب', 'چالدران', 'خوی', 'سردشت', 'سلماس', 'شاهین‌دژ', 'ماکو', 'مهاباد', 'میاندوآب', 'نقده'];
catAndActs['03'] = ['اردبیل', 'بیله‌سوار', 'پارس‌آباد', 'خلخال', 'کوثر', 'گِرمی', 'مِشگین‌شهر', 'نَمین', 'نیر'];
catAndActs['04'] = ['آران و بیدگل ', 'اردستان', 'اصفهان', 'برخوار و میمه', 'تیران و کرون', 'چادگان', 'خمینی‌شهر', 'خوانسار', 'سمیرم', 'شهرضا', 'سمیرم', 'سفلی', 'فریدن', 'فریدون‌شهر', 'فلاورجان', 'کاشان', 'گلپایگان', 'لنجان', 'مبارکه', 'نائین', 'نجف‌آباد', 'نطنز'];
catAndActs['05'] = ['چهارباغ', 'آسارا', 'کرج', 'طالقان', 'شهرجدیدهشتگرد', 'محمدشهر', 'مشکین دشت', 'نظرآباد', 'هشتگرد', 'ماهدشت', 'اشتهارد', 'کوهسار', 'گرمدره', 'تنکمان', 'گلسار', 'کمال شهر', 'فردیس'];
catAndActs['06'] = ['آبدانان', 'ایلام', 'ایوان', 'دره‌شهر', 'دهلران', 'شیروان و چرداول', 'مهران'];
catAndActs['07'] = ['بوشهر', 'تنگستان', 'جم', 'دشتستان', 'دشتی', 'دیر', 'دیلم', 'کنگان', 'گناوه'];
catAndActs['08'] = ['اسلام‌شهر', 'پاکدشت', 'تهران', 'دماوند', 'رباط‌کریم', 'ری', 'ساوجبلاغ', 'شمیرانات', 'شهریار', 'فیروزکوه', 'کرج', 'نظرآباد', 'ورامین'];
catAndActs['09'] = ['اردل', 'بروجن', 'شهرکرد', 'فارسان', 'کوهرنگ', 'لردگان'];
catAndActs['10'] = ['بیرجند', 'درمیان', 'سرایان', 'سربیشه', 'فردوس', 'قائنات', 'نهبندان'];
catAndActs['11'] = ['بردسکن', 'تایباد', 'تربت جام', 'تربت حیدریه', 'چناران', 'خلیل‌آباد', 'خواف', 'درگز', 'رشتخوار', 'سبزوار', 'سرخس', 'فریمان', 'قوچان', 'کاشمر', 'کلات', 'گناباد', 'مشهد', 'مه ولات', 'نیشابور'];
catAndActs['12'] = ['اسفراین', 'بجنورد', 'جاجرم', 'شیروان', 'فاروج', 'مانه و سملقان'];
catAndActs['13'] = ['آبادان', 'امیدیه', 'اندیمشک', 'اهواز', 'ایذه', 'باغ‌ملک', 'بندر ماهشهر ', 'بهبهان', 'خرمشهر', 'دزفول', 'دشت آزادگان', 'رامشیر', 'رامهرمز', 'شادگان', 'شوش', 'شوشتر', 'گتوند', 'لالی', 'مسجد سلیمان', 'هندیجان'];
catAndActs['14'] = ['ابهر', 'ایجرود', 'خدابنده', 'خرمدره', 'زنجان', 'طارم', 'ماه‌نشان'];
catAndActs['15'] = ['دامغان', 'سمنان', 'شاهرود', 'گرمسار', 'مهدی‌شهر'];
catAndActs['16'] = ['ایرانشهر', 'چابهار', 'خاش', 'دلگان', 'زابل', 'زاهدان', 'زهک', 'سراوان', 'سرباز', 'کنارک', 'نیک‌شهر'];
catAndActs['17'] = ['آباده', 'ارسنجان', 'استهبان', 'اقلید', 'بوانات', 'پاسارگاد', 'جهرم', 'خرم‌بید', 'خنج', 'داراب', 'زرین‌دشت', 'سپیدان', 'شیراز', 'فراشبند', 'فسا', 'فیروزآباد', 'قیر و کارزین', 'کازرون', 'لارستان', 'لامِرد', 'مرودشت', 'ممسنی', 'مهر', 'نی‌ریز'];
catAndActs['18'] = ['آبیک', 'البرز', 'بوئین‌زهرا', 'تاکستان', 'قزوین'];
catAndActs['19'] = ['بانه', 'بیجار', 'دیواندره', 'سروآباد', 'سقز', 'سنندج', 'قروه', 'کامیاران', 'مریوان'];
catAndActs['20'] = ['بافت', 'بردسیر', 'بم', 'جیرفت', 'راور', 'رفسنجان', 'رودبار جنوب', 'زرند', 'سیرجان', 'شهر بابک', 'عنبرآباد', 'قلعه گنج ', 'کرمان', 'کوهبنان', 'کهنوج', 'منوجان'];
catAndActs['21'] = ['اسلام‌آباد غرب', 'پاوه', 'ثلاث باباجانی', 'جوانرود', 'دالاهو', 'روانسر', 'سرپل ذهاب', 'سنقر', 'صحنه', 'قصر شیرین', 'کرمانشاه', 'کنگاور', 'گیلان غرب', 'هرسین'];
catAndActs['22'] = ['بویراحمد', 'بهمئی', 'دنا', 'کهگیلویه', 'گچساران'];
catAndActs['23'] = ['آزادشهر', 'آق‌قلا', 'بندر گز', 'ترکمن', 'رامیان', 'علی‌آباد', 'کردکوی', 'کلاله', 'گرگان', 'گنبد کاووس', 'مراوه‌تپه', 'مینودشت'];
catAndActs['24'] = ['آستارا', 'آستانه اشرفیه', 'اَملَش', 'بندر انزلی', 'رشت', 'رضوانشهر', 'رودبار', 'رودسر', 'سیاهکل', 'شَفت', 'صومعه‌سرا', 'طوالش', 'فومَن', 'لاهیجان', 'لنگرود', 'ماسال'];
catAndActs['25'] = ['ازنا', 'الیگودرز', 'بروجرد', 'پل‌دختر', 'خرم‌آباد', 'دورود', 'دلفان', 'سلسله', 'کوهدشت'];
catAndActs['26'] = ['آمل', 'بابل', 'بابلسر', 'بهشهر', 'تنکابن', 'جویبار', 'چالوس', 'رامسر', 'ساری', 'سوادکوه', 'قائم‌شهر', 'گلوگاه', 'محمودآباد', 'نکا', 'نور', 'نوشهر'];
catAndActs['27'] = ['آشتیان', 'اراک', 'تفرش', 'خمین', 'دلیجان', 'زرندیه', 'ساوه', 'شازند', 'کمیجان', 'محلات'];
catAndActs['28'] = ['ابوموسی', 'بستک', 'بندر عباس', 'بندر لنگه', 'جاسک', 'حاجی‌آباد', 'شهرستان خمیر', 'رودان', 'قشم', 'گاوبندی', 'میناب'];
catAndActs['29'] = ['اسدآباد', 'بهار', 'تویسرکان', 'رزن', 'کبودرآهنگ', 'ملایر', 'نهاوند', 'همدان'];
catAndActs['30'] = ['ابرکوه', 'اردکان', 'بافق', 'تفت', 'خاتم', 'صدوق', 'طبس', 'مهریز', 'مِیبُد', 'یزد'];

function ChangecatList() {
    var catList = document.getElementById("validationCustom03");
    var actList = document.getElementById("validationCustom04");
    var selCat = catList.options[catList.selectedIndex].value;
    while (actList.options.length) {
        actList.remove(0);
    }
    var cats = catAndActs[selCat];
    if (cats) {
        var i;
        for (i = 0; i < cats.length; i++) {
            var cat = new Option(cats[i], i);
            actList.options.add(cat);
        }
    }
}
$(function () {
    $("#radio-button-0").click(function () {
        if ($("#blk").hasClass("hidden")) {
            $("#blk").show('slow');
            $("#blk").removeClass("hidden");
           
        } else {
            $(this).addClass("hidden");
        }

    });
    $("#radio-button-1").click(function () {
        $("#blk").addClass("hidden"); 
    });
});



$(function () {
    $('.button-checkbox').each(function () {

        // Settings
        var $widget = $(this),
            $button = $widget.find('button'),
            $checkbox = $widget.find('input:checkbox'),
            color = $button.data('color'),
            settings = {
                on: {
                    icon: 'glyphicon glyphicon-check'
                },
                off: {
                    icon: 'glyphicon glyphicon-unchecked'
                }
            };

        // Event Handlers
        $button.on('click', function () {
            $checkbox.prop('checked', !$checkbox.is(':checked'));
            $checkbox.triggerHandler('change');
            updateDisplay();
        });
        $checkbox.on('change', function () {
            updateDisplay();
        });

        // Actions
        function updateDisplay() {
            var isChecked = $checkbox.is(':checked');

            // Set the button's state
            $button.data('state', (isChecked) ? "on" : "off");

            // Set the button's icon
            $button.find('.state-icon')
                .removeClass()
                .addClass('state-icon ' + settings[$button.data('state')].icon);

            // Update the button's color
            if (isChecked) {
                $button
                    .removeClass('btn-default')
                    .addClass('btn-' + color + ' active');
            }
            else {
                $button
                    .removeClass('btn-' + color + ' active')
                    .addClass('btn-default');
            }
        }

        // Initialization
        function init() {

            updateDisplay();

            // Inject the icon if applicable
            if ($button.find('.state-icon').length == 0) {
                $button.prepend('<i class="state-icon ' + settings[$button.data('state')].icon + '"></i> ');
            }
        }
        init();
    });
});
Vue.use(UploadInstaller);

Vue.use(UploadInstaller);

new Vue({
    el: "#vueapp",
    mounted: function () {
        /*
            The code in this function is only added to simulate a successful upload request for this demo.
            Do not use the code in other cases when working with the Upload component.
        */

        var postFormData = function (url, data, fileEntry, xhr) {
            var module = this;
            fileEntry.data("request", xhr);
            setTimeout(function () {
                var e = { target: { responseText: '', statusText: "OK", status: 200 } };
                module.onRequestSuccess.call(module, e, fileEntry);
            }, 1000);
        };
        var submitRemove = function (fileNames, eventArgs, onSuccess, onError) {
            onSuccess();
        };
        var upload = this.$refs.upload.kendoWidget();
        upload._module.postFormData = postFormData;
        upload._submitRemove = submitRemove;
    }
})
$(document).ready(function () {
    //@naresh action dynamic childs
    var next = 0;
    $("#add-more").click(function (e) {
        e.preventDefault();
        var addto = "#field" + next;
        var addRemove = "#field" + (next);
        next = next + 1;
        var newIn = ' <div id="field' + next + '" name="field' + next + '"><!-- Text input--><div class="form-group"> <label class="col-md-4 control-label" for="action_id">Action Id</label> <div class="col-md-5"> <input id="action_id" name="action_id" type="text" placeholder="" class="form-control input-md"> </div></div><br><br> <!-- Text input--><div class="form-group"> <label class="col-md-4 control-label" for="action_name">Action Name</label> <div class="col-md-5"> <input id="action_name" name="action_name" type="text" placeholder="" class="form-control input-md"> </div></div><br><br><!-- File Button --> <div class="form-group"> <label class="col-md-4 control-label" for="action_json">Action JSON File</label> <div class="col-md-4"> <input id="action_json" name="action_json" class="input-file" type="file"> </div></div></div>';
        var newInput = $(newIn);
        var removeBtn = '<button id="remove' + (next - 1) + '" class="btn btn-danger remove-me" >Remove</button></div></div><div id="field">';
        var removeButton = $(removeBtn);
        $(addto).after(newInput);
        $(addRemove).after(removeButton);
        $("#field" + next).attr('data-source', $(addto).attr('data-source'));
        $("#count").val(next);

        $('.remove-me').click(function (e) {
            e.preventDefault();
            var fieldNum = this.id.charAt(this.id.length - 1);
            var fieldID = "#field" + fieldNum;
            $(this).remove();
            $(fieldID).remove();
        });
    });

});
function startUpload() {
    var id = setInterval(frame, 50);
    var percent = 1;
    $('.btnprogress').text('Continue')
    function frame() {
        if (percent >= 100) {
            clearInterval(id);
            $('.btnprogress').text('Close')
        } else {
            percent++;
            $('.progress-bar').css('width', percent + '%').attr('aria-valuenow', percent);
        }
    }
}

function clickProgress() {
    var progress = $('.btnprogress').text();

    if (progress == 'Continue') {
        window.open(window.location.href);
    }
    else {
        $('#myModal').modal('toggle');
    }
}

