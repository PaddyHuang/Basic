FROM centos:latest
MAINTAINER paddyace <huangblcs@outlook.com>

ADD ./install.sh /usr/local
ADD ./vimrc /root/.vimrc
ADD ./ycm_extra_conf.py /home/.ycm_extra_conf.py

RUN chmod +x /usr/local/install.sh && /usr/local/install.sh

EXPOSE  22
EXPOSE  80

CMD /usr/sbin/sshd -D
