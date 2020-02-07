from tensorflow.keras.models import load_model
from tensorflow.keras import utils
from tensorflow.keras.preprocessing import image
import matplotlib.pyplot as plt
import numpy as np
import glob
from numpy import reshape


model = load_model('NotFace.h5')
model.summary()

imagesPaths = glob.iglob(r'pos\*.jpg')
counterPos = 0
counterNeg = 0

for imgPath in imagesPaths:
    img = image.load_img(imgPath, target_size=(96, 96), color_mode='rgb')
    x = image.img_to_array(img)
    x = x.reshape((1, 96, 96, 3))
    x = (127.5 - x) * 0.0078125
    prediction = model.predict(x)
    print(imgPath + ' ' + str(prediction[0]))
    if float(prediction[0]) < 0.2:
        counterPos += 1
    else:
        counterNeg += 1

print('pos: %i, neg: %i' % (counterPos, counterNeg))
