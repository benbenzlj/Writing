## Vue 项目中配置eslint检查typescript

### 插件
```javascript
"@typescript-eslint/eslint-plugin": "^1.6.0",
"@typescript-eslint/parser": "^1.6.0",
"eslint-plugin-vue"
"vue-eslint-parser"
```

### .eslintrc.js
```javascript
module.exports = {
    parser: "vue-eslint-parser",
    parserOptions: {
        parser: "@typescript-eslint/parser"
    },
    plugins: ["@typescript-eslint"],
    extends: [
        "plugin:@typescript-eslint/recommended",
        "plugin:vue/recommended"
    //"eslint:recommended",
    //"eslint:recommended",
    // add more generic rulesets here, such as:
    // 'eslint:recommended',
    //'plugin:vue/recommended',
    //"plugin:vue/strongly-recommended",
    ],
    rules: {
        "no-undef": "off"
    //"no-unused-vars": "off",
    //'no-unused-vars': "warn",
    //'no-console':"warn",
    // override/add rules settings here, such as:
    // "vue/no-unused-vars": "warn",
    // "vue/no-unused-components": "warn",
    // "vue/require-prop-types": "warn"
    }
};

```

### 注意
- 安装版本时需要注意，安装最新版本

### 参照文档
- [eslint-config-prettier配置](https://github.com/prettier/eslint-config-prettier#special-rules)
- [typescript-eslint规则列表及说明](https://github.com/typescript-eslint/typescript-eslint/tree/v1.6.0/packages/eslint-plugin/docs/rules)
- [Vue Eslint 官方插件文档](https://vuejs.github.io/eslint-plugin-vue)
- [Vue 编码风格指南中文](https://cn.vuejs.org/v2/style-guide/)