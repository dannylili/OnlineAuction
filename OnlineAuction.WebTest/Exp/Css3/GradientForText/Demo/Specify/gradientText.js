/*
gradientText v 1.02
copyright 2006 Thomas Frank

This program is free software under the terms of the 
GNU General Public License version 2 as published by the Free 
Software Foundation. It is distributed without any warranty.
*/

gradientText = {
    h2d: function (x) { return parseInt("0x" + x, 16) },
    d2h: function (x) {
        var y = "0123456789abcdef";
        var z = y.substr(x & 15, 1);
        while (x > 15) { x >>= 4; z = y.substr(x & 15, 1) + z };
        while (z.length < 2) { z = "0" + z };
        return z
    },
    create: function (startColor, endColor, steps) {
        var s = startColor; var e = endColor;
        if (typeof s != "string" || typeof e != "string") { return };
        s = s.replace(/\#/g, ""); e = e.replace(/\#/g, "");
        var s = s.toLowerCase().split(""); var e = e.toLowerCase().split("");
        if (s.length == 3) { s[5] = s[2]; s[4] = s[2]; s[3] = s[1]; s[2] = s[1]; s[1] = s[0] };
        if (e.length == 3) { e[5] = e[2]; e[4] = e[2]; e[3] = e[1]; e[2] = e[1]; e[1] = e[0] };
        if ((s.join("") + e.join("")).replace(/[0-f]/g, "") != "") { return };
        var r1 = this.h2d(s[0] + s[1]);
        var g1 = this.h2d(s[2] + s[3]);
        var b1 = this.h2d(s[4] + s[5]);
        var r2 = this.h2d(e[0] + e[1]);
        var g2 = this.h2d(e[2] + e[3]);
        var b2 = this.h2d(e[4] + e[5]);
        var r = r1; var g = g1; var b = b1;
        steps--;
        var rs = (r2 - r1) / steps;
        var gs = (g2 - g1) / steps;
        var bs = (b2 - b1) / steps;
        var a = [];
        for (var i = 0; i < steps; i++) {
            a.push(this.d2h(r) + this.d2h(g) + this.d2h(b));
            r += rs; g += gs; b += bs;
        };
        a.push(e.join(''));
        return a
    },
    applyOnText: function (text, startColor, endColor) {
        var inTag = false;
        var inChar = false;
        var orgtext = text;
        if (text.indexOf('gradientOrgTextDiv') >= 0) {
            text = text.substring(text.indexOf('gradientOrgTextDiv'));
            text = text.substring(text.indexOf(">") + 1);
            text = text.substring(0, text.lastIndexOf("<"));
        };
        var t = text.split("");
        var tagCo = text.split("<").length - 1;
        var a = [];
        for (var i = 0; i < t.length; i++) {
            if (inTag || inChar) { a[a.length - 1] += t[i] } else { a.push(t[i]) };
            inTag = t[i] == "<" ? true : t[i] == ">" ? false : inTag;
            inChar = t[i] == "&" ? true : t[i] == ";" ? false : inChar;
        };
        var g = this.create(startColor, endColor, a.length - tagCo);
        if (!g) { return orgtext };
        var gCo = 0;
        for (var i = 0; i < a.length; i++) {
            if (a[i].charAt(0) != "<") {
                a[i] = '<span style="color:#' + g[gCo] + '">' + a[i] + '</span>';
                gCo++;
            }
        };
        a = a.join('') + '<span style="display:none" id="gradientOrgTextDiv">' + text + '</span>';
        return a;
    },
    set: function (elements, startColor, endColor) {
        if (!document || !document.body) { setTimeout("gradientText.set()", 50); return };
        if (elements && elements.innerHTML) { elements = [elements] };
        var x = elements ? elements : document.getElementsByTagName('span');
        for (var i = 0; i < x.length; i++) {
            var c = x[i].className.split("_");
            if (elements) { c = ["gradient", startColor, endColor] };
            if (c[0] == "gradient" && c.length == 3) {
                x[i].innerHTML = this.applyOnText(x[i].innerHTML, c[1], c[2]);
            };
        }
    }
}
gradientText.set()