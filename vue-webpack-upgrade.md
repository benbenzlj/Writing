# Vue脚手架升级为4.x版本

## 替换package.json文件中的Webpack
```json
"devDependencies": {
    "webpack": "^4.8.1",
    "webpack-bundle-analyzer": "^2.9.0",
    "webpack-cli": "^3.1.1",
    "webpack-dev-server": "^3.1.4",
    "webpack-merge": "^4.1.0"
}
```
## 升级Babel为7.x版本
```json
 "devDependencies": {
    "@babel/core": "^7.0.0-beta.49",
    "@babel/plugin-syntax-dynamic-import": "^7.0.0",
    "@babel/plugin-syntax-jsx": "^7.0.0-beta.47",
    "@babel/plugin-transform-runtime": "^7.1.0",
    "@babel/preset-env": "^7.0.0-beta.47",
    "@babel/register": "^7.0.0-beta.49",
    "@vue/babel-plugin-transform-vue-jsx": "^0.1.0"
}
```

## 升级loader
- `babel-loader`
- `ts-loader`
  
## 插件
- `html-webpack-plugin`
- `extract-text-webpack-plugin` 替换为 `mini-css-extract-plugin`
- `progress-bar-webpack-plugin` 进度条


### 问题
- Babel 无法转换node_modules文件夹中的vue单文件组件
  - 将.babelr删除
  - 增加abel.config.js
  - 配置示例
    ```javascript
    module.exports = function (api) {
        api.cache(true)
        return {
            presets: [
            [
                '@babel/env',
                {
                'modules': false,
                'useBuiltIns':'usage',
                'targets': {
                    'browsers': [
                    '> 1%',
                    'last 2 versions',
                    'not ie <= 8'
                    ]
                }
                }
            ]
            ],
            plugins: [
            "@babel/transform-runtime",
            "@vue/babel-plugin-transform-vue-jsx",
            "@babel/plugin-syntax-dynamic-import"
            ],
            "ignore": [
            "src/lib/**/*.js"
            ]
        }
    }
    ```