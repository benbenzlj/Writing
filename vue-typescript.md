
## Vue + Typescript + ElementUI 填坑

### ElementUI

#### 验证控件使用

 1. 需要使用`this.$refs['form'].validate`方法
 2. 需要在组件中定义
```javascript
$refs!: {
    vue: Vue,
    element: HTMLInputElement,
    vues: Vue[],
    elements: HTMLInputElement[]
  }
```
