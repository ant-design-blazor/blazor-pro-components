var beforeStartCalled = false;
var afterStartedCalled = false;

export function beforeWebStart() {
    loadScriptAndStyle();
}

export function beforeStart(options, extensions) {
   loadScriptAndStyle();
}

function loadScriptAndStyle() {
    if (beforeStartCalled) {
        return;
    }

    beforeStartCalled = true;

    const antblazorCss = '_content/AntDesign/css/ant-design-blazor.css';
    const prolayoutCss = '_content/AntDesign.ProLayout/css/ant-design-pro-layout-blazor.css';

    if (!document.querySelector(`[href="${prolayoutCss}"]`)){
        var customStyle = document.createElement('link');
        customStyle.setAttribute('href', `${prolayoutCss}`);
        customStyle.setAttribute('rel', 'stylesheet');

        const antblazorStyle = document.querySelector(`[href="${antblazorCss}"]`);
        if (antblazorStyle) {
            antblazorStyle.after(customStyle);
        }
        else {
            console.log('no antblazorStyle')
            document.head.insertBefore(customStyle, document.querySelector('[prolayout-css]') || document.querySelector('link'));
        }
    }
}