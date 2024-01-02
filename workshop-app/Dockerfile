FROM node:lts-alpine
ENV NODE_ENV=production
WORKDIR /workshop-app
RUN npm install -g @angular/cli
COPY  ./workshop-app/package.json /workshop-app
RUN npm install --production --silent && mv node_modules ../
COPY . .
EXPOSE 4200
RUN chown -R node /workshop-app
USER node
CMD ["npm", "run", "start"]
