## 统计学公式


###　求和

$$ \mu = \frac{\Sigma_{fx}}{n} $$

### 方差

$$ 
\sigma^2 = \frac{\Sigma x^2}{n} - \mu^2
$$
$$
\sigma^2 = \frac{\Sigma (x-\mu)^2}{n}
$$

### 全距
全距 = 数据上界 - 下界

### 四分位距
四分位距 = 上四分位数 - 下四分位数
上四分位数 = $ n \div 4 $
下四分位数 = $ 3n \div 4 $ 

### 标准差
$$ \sigma = \sqrt{\frac{\Sigma x^2}{n}-\mu^2} $$

### 标准分

$$
\Zeta = \frac{x-\mu}{\sigma}
$$

## 概率

$$
P(A) = \frac{n(A)}{n(S)}
$$

- $ n(A) $ 发生事件A的可能数目
- $ n(S) $ 所有可能结果的数目


**无论某事件多么不可能发生，只要不是完全不可能发生，该事件就仍然可能发生**                               
### 维恩图
- 互斥事件：如果两个事件是互斥事件，则其中只有一个事件会发生
  - 符号表示： $ P(A\cap B ) =0  $
- 相交事件：如果两个事件相交，则这两个事件有可能同时发生
  - 符号表示：$ P(A \cap B) $
- 穷举
  - 符号表示：$ P(A \cup B) = 1 $
- A或B
  - $ P(A \cup B) = P(A) + P(B) - P(A \cap B) $

### 条件概率
$$
P(A \mid B) = \frac{P(A \cap B)}{P(B)} 
$$

- 衍生公式
  - $ P(A \cap B) = P(A \mid B) * P(B) $
  - $ P(B \cap A) = P(B \mid A) * P(A) $

### 贝叶斯定理

$$
P(A \mid  B) = \frac{P(A)*P(B \mid A)}{P(A)*P(B \mid A) + P(A')*P(B \mid A')}
$$  