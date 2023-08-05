from pandas import read_csv
from sklearn.model_selection import KFold
from sklearn.metrics import confusion_matrix
from sklearn.metrics import accuracy_score
from sklearn.model_selection import cross_val_score
from sklearn.neighbors import KNeighborsClassifier
from sklearn.ensemble.forest import RandomForestClassifier

from sklearn import metrics, naive_bayes
from sklearn.tree.tree import DecisionTreeClassifier
from sklearn.ensemble.gradient_boosting import GradientBoostingClassifier
from sklearn.naive_bayes import GaussianNB
from sklearn.svm.classes import SVC
import numpy as np
import matplotlib.pyplot as plt
from sklearn.neighbors.classification import KNeighborsClassifier

# filenamet ="/home/nisha/workspace/revision_result/src/TrainBM7_cshuf.csv"
filename = "copout1000.csv"

dataframe = read_csv(filename)
array = dataframe.values
print(array[0])
Num_cols = array.shape
print(Num_cols)
X_train = array[0:650, 0:88]
Y_train = array[0:650, 88]
X_test = array[650:, 0:88]
Y_test = array[650:, 88]

print(X_train)
print(Y_train)
print(Y_test)

model = RandomForestClassifier()

model.fit(X_train, Y_train)
#print(model)
# make predictions
c = model.predict(X_test)
#print(c)
print(c)

correct = 0
for x in range(len(Y_test)):
        if Y_test[x] == c[x]:
            correct += 1
            res = (correct/int(len(Y_test))) if(int(len(Y_test))) != 0 else 0
            res1 = res*100
print(res1)

print(metrics.classification_report(Y_test, c))
print(metrics.confusion_matrix(Y_test, c))
print(accuracy_score(Y_test, c))

TP = np.sum(np.logical_and(c == 1, Y_test == 1))

TN = np.sum(np.logical_and(c == 0,Y_test == 0))

FN = np.sum(np.logical_and(c== 0, Y_test == 1))

FP = np.sum(np.logical_and(c== 1, Y_test == 0))

print('TP: %i, FP: %i, TN: %i, FN: %i' % (TP,FP,TN,FN))

clf4 = SVC(kernel="linear", random_state=0, probability=True)
clf4.fit(X_train, Y_train)
y_pred4 = clf4.predict(X_test)
res1 = metrics.accuracy_score(Y_test, y_pred4)
print("Accuracy-SVC", res1)
y_pred_proba4 = clf4.predict_proba(X_test)[::, 1]
fpr4, tpr4, _ = metrics.roc_curve(Y_test, y_pred_proba4)
auc4 = metrics.roc_auc_score(Y_test, y_pred_proba4)
print(metrics.confusion_matrix(Y_test, y_pred4))
plt.plot(fpr4, tpr4, label="SVC, auc=" + str(auc4))

TP = np.sum(np.logical_and(y_pred4 == 1, Y_test == 1))

# True Negative (TN): we predict a label of 0 (negative), and the true label is 0.
TN = np.sum(np.logical_and(y_pred4 == 0, Y_test == 0))

# False Positive (FP): we predict a label of 1 (positive), but the true label is 0.
FN = np.sum(np.logical_and(y_pred4 == 0, Y_test == 1))

# False Negative (FN): we predict a label of 0 (negative), but the true label is 1.
FP = np.sum(np.logical_and(y_pred4 == 1, Y_test == 0))

print ('TP: %i, FP: %i, TN: %i, FN: %i' % (TP, FP, TN, FN))

plt.xlim([0.0, 1.0])
plt.ylim([0.1, 1.0])
plt.yticks(np.arange(0.1, 1.0, 0.1))
plt.xticks(np.arange(0.0, 1.0, 0.1))
plt.xlabel('False Positive Rate')
plt.ylabel('True Positive Rate')
plt.legend(loc=2)
plt.show()

